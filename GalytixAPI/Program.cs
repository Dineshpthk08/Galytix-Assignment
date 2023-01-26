using GalytixAPI.Business.Implementation;
using GalytixAPI.Business.Interfaces;
using GalytixAPI.DataAccess;
using GalytixAPI.Entities;
using GalytixAPI.Repository.Implementation;
using GalytixAPI.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GwpDbContext>(options => options.UseInMemoryDatabase("GwpDB"));

builder.Services.AddTransient<IGwpRepository, GwpRepository>();
builder.Services.AddTransient<IGwpManager, GwpManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
