using AuthService.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Extensions;

public static class WebApplicationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var services = app.ApplicationServices.CreateScope();

        var dbContext = services.ServiceProvider.GetService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}