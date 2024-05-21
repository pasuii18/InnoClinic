using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Seeds;

public class AppDbSeeds
{
    public static void InitializeData(AppDbContext dbContext, UserManager<IdentityUser> userManager)
    {
         var user = new IdentityUser("Bob");
         userManager.CreateAsync(user, "password").GetAwaiter().GetResult();
         userManager.AddClaimAsync(user, new Claim("custom_claim", "cool_info")).GetAwaiter().GetResult();
        
         // scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
         // var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
         // context.Database.Migrate();
         // if (!context.Clients.Any())
         // {
         //     foreach (var client in Configuration.GetClients())
         //     {
         //         context.Clients.Add(client.ToEntity());
         //     }
         //     context.SaveChanges();
         // }
         //
         // if (!context.IdentityResources.Any())
         // {
         //     foreach (var resource in Configuration.GetIdentityResources())
         //     {
         //         context.IdentityResources.Add(resource.ToEntity());
         //     }
         //     context.SaveChanges();
         // }
         //
         // if (!context.ApiResources.Any())
         // {
         //     foreach (var resource in Configuration.GetApiResources())
         //     {
         //         context.ApiResources.Add(resource.ToEntity());
         //     }
         //     context.SaveChanges();
         // }
         //
         // if (!context.ApiScopes.Any())
         // {
         //     foreach (var apiScope in Configuration.GetApiScopes())
         //     {
         //         context.ApiScopes.Add(apiScope.ToEntity());
         //     }
         //     context.SaveChanges();
         // }
    }
}