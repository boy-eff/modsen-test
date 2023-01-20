using MediatR;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public record UpdateModsenEventCommand(ModsenEventDto ModsenEventDto) : IRequest;