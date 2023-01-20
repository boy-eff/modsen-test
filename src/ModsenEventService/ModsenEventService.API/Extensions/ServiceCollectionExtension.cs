using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ModsenEventService.Application.Interfaces;
using ModsenEventService.Infrastructure.Data;
using ModsenEventService.Infrastructure.Data.Repositories;

namespace ModsenEventService.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            return services.AddScoped<IModsenEventRepository, ModsenEventRepository>();
        }
        
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
        
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, string authority)
        {
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options => 
                    {
                        options.Authority = authority;
                        options.RequireHttpsMetadata = false;
                    });
            return services;
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options => 
            {
                options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}