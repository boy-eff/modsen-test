using Microsoft.EntityFrameworkCore;
using ModsenEventService.Application.Interfaces;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Infrastructure.Data.Repositories;

public class ModsenEventRepository : IModsenEventRepository
{
    private ApplicationDbContext _context;

    public ModsenEventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<ModsenEvent>> GetModsenEventsAsync()
    {
        return await _context.ModsenEvents.ToListAsync();
    }

    public async Task<ModsenEvent> GetModsenEventByIdAsync(Guid id)
    {
        return await _context.ModsenEvents.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Guid> AddModsenEventAsync(ModsenEvent modsenEvent)
    {
        await _context.ModsenEvents.AddAsync(modsenEvent);
        await _context.SaveChangesAsync();
        return modsenEvent.Id;
    }

    public async Task DeleteModsenEventAsync(Guid id)
    {
        var modsenEvent = await _context.ModsenEvents.FindAsync(id);
        if (modsenEvent is not null)
        {
            _context.ModsenEvents.Remove(modsenEvent);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateModsenEventAsync(ModsenEvent modsenEvent)
    {
        _context.ModsenEvents.Entry(modsenEvent).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}