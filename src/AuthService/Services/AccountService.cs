using AuthService.Data.Models;
using AuthService.Dtos;
using AuthService.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public AccountService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Guid> RegisterUserAsync(RegisterUserDto registerUserDto)
    {
        var appUser = _mapper.Map<AppUser>(registerUserDto);
        var createResult = await _userManager.CreateAsync(appUser, registerUserDto.Password);
        if (!createResult.Succeeded)
        {
            Console.WriteLine("FAIL");
            return Guid.Empty;
        }

        return appUser.Id;
    }
}