namespace AuthService.Interfaces;

public interface IAccountService
{
    Task<Guid> RegisterUserAsync();
}