using System.Reflection;
using MediatR;
using ModsenEventService.API.Extensions;
using ModsenEventService.Application.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddScopedServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseConfiguration(config.GetConnectionString("Default"));
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();