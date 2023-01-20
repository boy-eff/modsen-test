using Microsoft.AspNetCore.Identity;

namespace AuthService.Data.Models;

public class AppUser : IdentityUser<Guid>
{
    public override Guid Id { get; set; } = Guid.NewGuid();
}