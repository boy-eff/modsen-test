namespace ModsenEventService.Domain.Models;

public class ModsenEvent
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Theme { get; set; }
    public string Description { get; set; }
    public string Speaker { get; set; }
    public DateTime Time { get; set; }
    public string Place { get; set; }
    public DateTimeOffset CreationTime { get; } = DateTimeOffset.Now.ToUniversalTime();
}