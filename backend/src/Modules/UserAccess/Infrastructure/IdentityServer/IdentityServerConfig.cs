using AutoHub.Modules.UserAccess.Application.Contracts;
using IdentityServer4;
using IdentityServer4.Models;

namespace AutoHub.Modules.UserAccess.Infrastructure.IdentityServer
{
    internal class IdentityServerConfig
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new("all", "Can Do All")
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new("AutoHubApi", "AutoHubApi")
                {
                    Scopes = { "all" }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(CustomClaimTypes.Roles, new List<string>
                {
                    CustomClaimTypes.Roles
                })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "AutoHubClientId",
                    ClientName = "AutoHubApi",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins =
                    {
                        "https://localhost:7429"
                    },
                    ClientSecrets =
                    {
                        new Secret("AutoHubSecret".Sha256())
                    },
                    AllowedScopes =
                    {
                        "all",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowAccessTokensViaBrowser = true,
                    AllowOfflineAccess = true,
                    RedirectUris = { "https://localhost:7249/swagger/oauth2-redirect.html" },
                }
            };
        }
    }
}