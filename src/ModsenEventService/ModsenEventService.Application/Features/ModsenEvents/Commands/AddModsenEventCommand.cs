using MediatR;
using ModsenEventService.Application.Dtos;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public class AddModsenEventCommand : IRequest<Guid>
{
    public AddModsenEventCommand(ModsenEventDto modsenEventDto)
    {
        ModsenEventDto = modsenEventDto;
    }

    public ModsenEventDto ModsenEventDto { get; }
}