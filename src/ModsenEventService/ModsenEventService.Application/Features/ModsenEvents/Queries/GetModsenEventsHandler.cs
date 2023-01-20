using AutoMapper;
using MediatR;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Application.Interfaces;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Features.ModsenEvents.Queries;

public class GetModsenEventsHandler : IRequestHandler<GetModsenEventsQuery, IList<ModsenEventDto>>
{
    private readonly IModsenEventRepository _modsenEventRepository;
    private readonly IMapper _mapper;

    public GetModsenEventsHandler(IModsenEventRepository modsenEventRepository, IMapper mapper)
    {
        _modsenEventRepository = modsenEventRepository;
        _mapper = mapper;
    }

    public async Task<IList<ModsenEventDto>> Handle(GetModsenEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await _modsenEventRepository.GetModsenEventsAsync();
        var dtos = _mapper.Map<List<ModsenEventDto>>(events);
        return dtos;
    }
}