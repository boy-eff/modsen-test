using Microsoft.EntityFrameworkCore;
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
    }
}