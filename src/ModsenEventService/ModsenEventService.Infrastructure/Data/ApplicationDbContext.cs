using Microsoft.EntityFrameworkCore;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    protected ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ModsenEvent> ModsenEvents { get; set; }
}