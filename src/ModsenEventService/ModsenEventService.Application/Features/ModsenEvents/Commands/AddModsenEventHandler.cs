using AutoMapper;
using MediatR;
using ModsenEventService.Application.Interfaces;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Features.ModsenEvents.Commands;

public class AddModsenEventHandler : IRequestHandler<AddModsenEventCommand, Guid>
{
    private readonly IModsenEventRepository _modsenEventRepository;
    private readonly IMapper _mapper;

    public AddModsenEventHandler(IModsenEventRepository modsenEventRepository, IMapper mapper)
    {
        _modsenEventRepository = modsenEventRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AddModsenEventCommand request, CancellationToken cancellationToken)
    {
        var modsenEvent = _mapper.Map<ModsenEvent>(request.ModsenEventDto);
        return await _modsenEventRepository.AddModsenEventAsync(modsenEvent);
    }
}