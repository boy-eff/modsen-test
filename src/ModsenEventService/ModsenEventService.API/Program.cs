using System.Net;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using ModsenEventService.API.Extensions;
using ModsenEventService.Application.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddScopedServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDatabaseConfiguration(config.GetConnectionString("Default"));
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddAuthenticationConfiguration(config["IdentityServer:Authority"]);
builder.Services.AddControllers();

var app = builder.Build();
app.ConfigureExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();