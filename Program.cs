using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Rodriguez_Camani_Feresin_Backend.Models;
using Rodriguez_Camani_Feresin_Backend;
using System.Reflection;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
);

var configuration = builder.Configuration;

builder.Services.AddDbContext<RodriguezCamaniFeresinContext>(options =>
    options.UseMySql(configuration.GetConnectionString("MySQLConnection"), 
       ServerVersion.Parse("8.0.36-mysql")));

#region Repositories
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
//builder.Services.AddScoped<IClientRepository, ClientRepository>();
#endregion

#region Services 
builder.Services.AddScoped<IAdminService, AdminService>();
//builder.Services.AddScoped<IClientService, ClientService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();