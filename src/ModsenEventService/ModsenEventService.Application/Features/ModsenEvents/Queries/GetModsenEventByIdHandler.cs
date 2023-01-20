using AutoMapper;
using MediatR;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Application.Interfaces;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Features.ModsenEvents.Queries;

public class GetModsenEventByIdHandler : IRequestHandler<GetModsenEventByIdQuery, ModsenEventDto>
{
    private readonly IModsenEventRepository _modsenEventRepository;
    private readonly IMapper _mapper;

    public GetModsenEventByIdHandler(IModsenEventRepository modsenEventRepository, IMapper mapper)
    {
        _modsenEventRepository = modsenEventRepository;
        _mapper = mapper;
    }

    public async Task<ModsenEventDto> Handle(GetModsenEventByIdQuery request, CancellationToken cancellationToken)
    {
        var dto =  await _modsenEventRepository.GetModsenEventByIdAsync(request.EventId);
        return _mapper.Map<ModsenEventDto>(dto);
    }
}