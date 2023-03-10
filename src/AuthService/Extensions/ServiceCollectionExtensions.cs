using AuthService.Data;
using AuthService.Data.Models;
using AuthService.Helpers.IdentityServer;
using AuthService.Interfaces;
using AuthService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace AuthService.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
    }
    
    public static void AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
    {
        if (connectionString is null)
        {
            throw new Exception("Connection string is not specified");
        }
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }
    
    public static void AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
    }

    public static void AddAspNetIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static void AddIdentityServerConfiguration(this IServiceCollection services, string issuerUri)
    {
        services.AddIdentityServer(options =>
            {
                options.IssuerUri = issuerUri;
            })
            .AddDeveloperSigningCredential()
            .AddAspNetIdentity<AppUser>()
            .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
            .AddInMemoryClients(IdentityServerConfig.Clients);
    }

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        return services.AddSwaggerGen(options => {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    Password = new OpenApiOAuthFlow()
                    {
                        TokenUrl = new Uri("/connect/token", UriKind.Relative)
                    }
                }
            });
        });
    }
}