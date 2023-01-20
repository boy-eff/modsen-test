using AutoMapper;
using MediatR;
using ModsenEventService.Application.Interfaces;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public class UpdateModsenEventHandler : IRequestHandler<UpdateModsenEventCommand>
{
    private readonly IModsenEventRepository _modsenEventRepository;
    private readonly IMapper _mapper;

    public UpdateModsenEventHandler(IModsenEventRepository modsenEventRepository, IMapper mapper)
    {
        _modsenEventRepository = modsenEventRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateModsenEventCommand request, CancellationToken cancellationToken)
    {
        var modsenEvent = _mapper.Map<ModsenEvent>(request.ModsenEventDto);
        await _modsenEventRepository.UpdateModsenEventAsync(modsenEvent);
        return Unit.Value;
    }
}