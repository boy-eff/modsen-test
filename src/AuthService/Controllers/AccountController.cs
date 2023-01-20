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
    public async Task<IActionResult> CreateUser([FromBody]RegisterUserDto dto)
    {
        var userId = await _accountService.RegisterUserAsync(dto);
        if (userId == Guid.Empty)
        {
            return BadRequest();
        }

        return Ok(userId);
    }
}