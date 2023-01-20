using Microsoft.AspNetCore.Identity;

namespace AuthService.Data.Models;

public class AppRole : IdentityRole<Guid>
{
    public override Guid Id { get; set; } = Guid.NewGuid();
}