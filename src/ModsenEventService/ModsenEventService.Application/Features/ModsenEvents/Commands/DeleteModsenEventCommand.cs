using MediatR;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public class DeleteModsenEventCommand : IRequest
{
    public DeleteModsenEventCommand(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; }
}