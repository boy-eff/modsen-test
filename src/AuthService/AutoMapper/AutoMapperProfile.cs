using AuthService.Data.Models;
using AuthService.Dtos;
using AutoMapper;

namespace AuthService.AutoMapper;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterUserDto, AppUser>().ReverseMap();
    }
}