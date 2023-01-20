using MediatR;
using ModsenEventService.Application.Dtos;

namespace ModsenEventService.Application.Features.ModsenEvents.Queries;

public class GetModsenEventsQuery : IRequest<IList<ModsenEventDto>>
{
    
}