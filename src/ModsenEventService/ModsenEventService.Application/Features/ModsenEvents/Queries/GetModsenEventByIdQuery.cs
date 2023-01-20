using MediatR;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Features.ModsenEvents.Queries;

public record GetModsenEventByIdQuery(Guid EventId) : IRequest, IRequest<ModsenEventDto>;