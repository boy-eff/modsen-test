using IdentityModel;
using IdentityServer4.Models;

namespace AuthService.IdentityServer;

public class IdentityServerConfig
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>()
        {
            new ApiScope("modsen-events")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>()
        {
            new Client()
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("secret".ToSha256())
                },
                AllowedScopes = { "modsen-events" }
            }
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
}