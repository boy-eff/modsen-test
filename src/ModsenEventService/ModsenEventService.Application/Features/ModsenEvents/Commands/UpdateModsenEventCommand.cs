using MediatR;
using ModsenEventService.Application.Dtos;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public class UpdateModsenEventCommand : IRequest
{
    public UpdateModsenEventCommand(ModsenEventDto modsenEventDto)
    {
        ModsenEventDto = modsenEventDto;
    }

    public ModsenEventDto ModsenEventDto { get; }
}