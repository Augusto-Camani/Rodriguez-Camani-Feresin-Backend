using Microsoft.EntityFrameworkCore;
using Rodriguez_Camani_Feresin_Backend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
);

var configuration = builder.Configuration;

builder.Services.AddDbContext<DbContextCFR>(options =>
    options.UseMySql(configuration.GetConnectionString("MySQLConnection"),
    ServerVersion.Parse("8.0.36-mysql")));

#region Repositories
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
//builder.Services.AddScoped<IClientRepository, ClientRepository>();
//builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
#endregion

#region Services 
builder.Services.AddScoped<IAdminService, AdminService>();
//builder.Services.AddScoped<IClientService, ClientService>();
//builder.Services.AddScoped<IReviewService, ReviewService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();