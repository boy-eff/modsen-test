using AuthService.Dtos;

namespace AuthService.Interfaces;

public interface IAccountService
{
    Task<Guid> RegisterUserAsync(RegisterUserDto registerUserDto);
}