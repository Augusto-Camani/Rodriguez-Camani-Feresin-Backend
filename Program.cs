using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rodriguez_Camani_Feresin_Backend;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Implementations;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Services.Implementations;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policys",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("usertype", "Admin"));
    options.AddPolicy("ClientPolicy", policy => policy.RequireClaim("usertype", "Client"));
    options.AddPolicy("BarberPolicy", policy => policy.RequireClaim("usertype", "Barber"));
    options.AddPolicy("BothPolicy", policy => policy.RequireClaim("usertype", "Admin", "Client" ,"Barber"));
});

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("RodriguezCamaniFeresinApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "RodriguezCamaniFeresinApiBearerAuth" }
                }, new List<string>() }
    });
    setupAction.ExampleFilters();
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<BarberScheduleDTOExample>();

var configuration = builder.Configuration;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    }
);

// builder.Services.AddDbContext<DbContextCFR>(options =>
//     options.UseMySql(configuration.GetConnectionString("MySQLConnection"),
//     ServerVersion.Parse("8.0.36-mysql")));

builder.Services.AddDbContext<DbContextCFR>(options =>
{
    options.UseSqlite("DataSource=MyDatabase.db");
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Repositories
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IBarberScheduleRepository, BarberScheduleRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
#endregion

#region Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IBarberScheduleService, BarberShceduleService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
#endregion

#region Security Services
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
#endregion

#region Adapters
builder.Services.AddScoped<IAppointmentScheduleAdapter, AppointmentScheduleAdapter>();
#endregion

#region Factories
builder.Services.AddScoped<IBarberScheduleFactory, BarberScheduleFactory>();
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("Policys");
app.Run();