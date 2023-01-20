using MediatR;
using ModsenEventService.Application.Interfaces;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public class DeleteModsenEventHandler : IRequestHandler<DeleteModsenEventCommand>
{
    private readonly IModsenEventRepository _modsenEventRepository;

    public DeleteModsenEventHandler(IModsenEventRepository modsenEventRepository)
    {
        _modsenEventRepository = modsenEventRepository;
    }

    public async Task<Unit> Handle(DeleteModsenEventCommand request, CancellationToken cancellationToken)
    {
        await _modsenEventRepository.DeleteModsenEventAsync(request.EventId);
        return Unit.Value;
    }
}