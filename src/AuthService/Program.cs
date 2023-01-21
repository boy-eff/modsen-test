using AuthService.Extensions;
using AuthService.Helpers.AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
var issuerUri = builder.Configuration["IssuerUri"];
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScopedServices();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddDatabaseConfiguration(connectionString);

builder.Services.AddAuthenticationConfiguration();
builder.Services.AddAuthorization();
builder.Services.AddAspNetIdentityConfiguration();
builder.Services.AddIdentityServerConfiguration(issuerUri);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();

app.ApplyMigrations();

app.MapControllers();

app.Run();
