using AuthService.Dtos;
using AuthService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController: ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<Guid> CreateUser([FromBody]RegisterUserDto dto)
    {
        return await _accountService.RegisterUserAsync(dto);
    }
}