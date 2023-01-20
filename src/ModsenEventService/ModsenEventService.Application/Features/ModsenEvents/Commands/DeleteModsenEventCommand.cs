using MediatR;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public record DeleteModsenEventCommand(Guid EventId) : IRequest;