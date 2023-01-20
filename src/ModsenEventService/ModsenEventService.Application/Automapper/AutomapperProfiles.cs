using AutoMapper;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.Application.Automapper;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        CreateMap<ModsenEvent, ModsenEventDto>().ReverseMap();
    }
}