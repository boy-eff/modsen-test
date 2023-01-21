using AutoMapper;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Helpers.AutoMapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<ModsenEvent, ModsenEventDto>().ReverseMap();
    }
}