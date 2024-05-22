using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Infrastructure.Common.Configs;

public static class Configuration
{
    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource("GatewayAPI")
            {
                Scopes = { "GatewayAccess" }
            }
        };
    
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
    
    public static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope>
        {
            new ApiScope("GatewayAccess"),
        };

    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client // fix: redirect uris and scoped
            {
                ClientId = "ClientWebApp",
                ClientSecrets = { new Secret("ClientWebAppSecret".ToSha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RedirectUris = { "https://localhost:44323/signin-oidc"},
                PostLogoutRedirectUris = { "https://localhost:44323/Home/Home"},
                AllowedScopes = 
                { 
                    "GatewayAccess", 
                    IdentityServerConstants.StandardScopes.OpenId, 
                    IdentityServerConstants.StandardScopes.Profile
                },
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
            },
            new Client // fix: redirect uris and scoped
            {
                ClientId = "InternalClinicPortal",
                ClientSecrets = { new Secret("InternalClinicPortalSecret".ToSha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RedirectUris = { "https://localhost:44323/signin-oidc"},
                PostLogoutRedirectUris = { "https://localhost:44323/Home/Home"},
                AllowedScopes = 
                { 
                    "GatewayAccess", 
                    IdentityServerConstants.StandardScopes.OpenId, 
                    IdentityServerConstants.StandardScopes.Profile
                },
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
            }
        };
}