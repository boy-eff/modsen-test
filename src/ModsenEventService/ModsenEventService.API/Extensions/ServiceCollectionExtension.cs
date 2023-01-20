using Microsoft.EntityFrameworkCore;
using ModsenEventService.Infrastructure.Data;

namespace ModsenEventService.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
    }
}