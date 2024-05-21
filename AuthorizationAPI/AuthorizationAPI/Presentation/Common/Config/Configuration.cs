using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Presentation.Common.Config;

public static class Configuration
{
    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource("GatewayAPI")
            {
                Scopes = { "GatewayAccess" }
            },
            new ApiResource("ClientWebApp")
            {
                Scopes = { "GatewayAccess", "ClientWebApp" }
            }
        };
    
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "new_scope",
                UserClaims =
                {
                    "custom_claim"
                }
            }
        };
    
    public static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope>
        {
            new ApiScope("GatewayAccess"),
            new ApiScope("ClientWebApp"),
        };

    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "InternalClinicPortal",
                ClientSecrets = { new Secret("internalClinicPortalSecret".ToSha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RedirectUris = { "https://localhost:44323/signin-oidc"},
                PostLogoutRedirectUris = { "https://localhost:44323/Home/Home"},
                AllowedScopes = 
                { 
                    "GatewayAccess", 
                    "ClientWebApp", 
                    IdentityServerConstants.StandardScopes.OpenId, 
                    IdentityServerConstants.StandardScopes.Profile,
                    "new_scope"
                },
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
            },
            new Client
            {
                ClientId = "AngularClient",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,
                RedirectUris = { "https://localhost:44323/signin-oidc"},
                PostLogoutRedirectUris = { "https://localhost:44323/Home/Home"},
                AllowedScopes = 
                { 
                    "GatewayAccess", 
                    IdentityServerConstants.StandardScopes.OpenId, 
                    IdentityServerConstants.StandardScopes.Profile,
                },
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
            }
        };
}