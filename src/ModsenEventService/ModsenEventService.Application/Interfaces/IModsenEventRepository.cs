using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Interfaces;

public interface IModsenEventRepository
{
    Task<IList<ModsenEvent>> GetModsenEventsAsync();
    Task<ModsenEvent> GetModsenEventByIdAsync(Guid id);
    Task<Guid> AddModsenEventAsync(ModsenEvent modsenEvent);
    Task DeleteModsenEventAsync(Guid id);
    Task UpdateModsenEventAsync(ModsenEvent modsenEvent);
}