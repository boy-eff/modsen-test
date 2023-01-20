using MediatR;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Features.ModsenEvents.Queries;

public class GetModsenEventByIdQuery : IRequest<ModsenEventDto>
{
    public GetModsenEventByIdQuery(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; }
}