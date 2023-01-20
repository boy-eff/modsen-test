using MediatR;
using ModsenEventService.Application.Dtos;

namespace ModsenEventService.Application.Features.ModsenEvents.Queries;

public record GetModsenEventsQuery() : IRequest, IRequest<IList<ModsenEventDto>>;