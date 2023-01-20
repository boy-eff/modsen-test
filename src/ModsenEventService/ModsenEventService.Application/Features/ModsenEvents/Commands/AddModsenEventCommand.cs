using MediatR;
using ModsenEventService.Application.Dtos;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public record AddModsenEventCommand(ModsenEventDto ModsenEventDto) : IRequest, IRequest<Guid>;