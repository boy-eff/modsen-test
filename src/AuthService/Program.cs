using AuthService.AutoMapper;
using AuthService.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScopedServices();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddDatabaseConfiguration(connectionString);

builder.Services.AddAuthenticationConfiguration();
builder.Services.AddAuthorization();
builder.Services.AddAspNetIdentityConfiguration();
builder.Services.AddIdentityServerConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
