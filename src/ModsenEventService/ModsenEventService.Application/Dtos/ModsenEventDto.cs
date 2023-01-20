namespace ModsenEventService.Application.Dtos;

public class ModsenEventDto
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Name { get; init; }
    public string Theme { get; init; }
    public string Description { get; init; }
    public string Speaker { get; init; }
    public DateTime Time { get; init; }
    public string Place { get; init; }
}