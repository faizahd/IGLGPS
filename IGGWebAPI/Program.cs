
using IGGWebAPI.Application.Interfaces;
using IGGWebAPI.Application.Services;
using IGGWebAPI.Infrastructure.Data;
using IGGWebAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DbContext with connection string from config
builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddScoped<GPSDeviceRepository>();
builder.Services.AddScoped<IGPSDeviceRepository, GPSDeviceRepository>();
//builder.Services.AddScoped<IGPSDeviceService, GPSDeviceService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
