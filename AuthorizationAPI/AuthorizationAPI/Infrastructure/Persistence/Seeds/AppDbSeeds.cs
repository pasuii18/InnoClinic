using System.Security.Claims;
using Domain.Entities;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Infrastructure.Common.Configs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Seeds;

public class AppDbSeeds
{
    public static void InitializeData(AppDbContext dbContext, IServiceScope scope)
    {
         var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
         
         var user = new User
         {
             UserName = "mail@gmail.com",
             Email = "mail@gmail.com"
         };
         var result = userManager.CreateAsync(user, "password").GetAwaiter().GetResult();
         
         // some debug stuff and i really hate this((((
         if (result.Succeeded)
         {
             var existingUser = userManager.FindByEmailAsync(user.Email).GetAwaiter().GetResult();
             if (existingUser != null)
             {
                 Console.WriteLine("Created!");
             }
             else
             {
                 Console.WriteLine("Not found after creating!");
             }
         }
         else
         {
             Console.WriteLine("Error!");
             foreach (var error in result.Errors)
             {
                 Console.WriteLine($"Error: {error.Description}");
             }
         }
         // userManager.AddClaimAsync(user, new Claim("custom_claim", "cool_info")).GetAwaiter().GetResult();
        
         scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
         var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
         context.Database.Migrate();
         if (!context.Clients.Any())
         {
             foreach (var client in Configuration.GetClients())
             {
                 context.Clients.Add(client.ToEntity());
             }
             context.SaveChanges();
         }
         
         if (!context.IdentityResources.Any())
         {
             foreach (var resource in Configuration.GetIdentityResources())
             {
                 context.IdentityResources.Add(resource.ToEntity());
             }
             context.SaveChanges();
         }
         
         if (!context.ApiResources.Any())
         {
             foreach (var resource in Configuration.GetApiResources())
             {
                 context.ApiResources.Add(resource.ToEntity());
             }
             context.SaveChanges();
         }
         
         if (!context.ApiScopes.Any())
         {
             foreach (var apiScope in Configuration.GetApiScopes())
             {
                 context.ApiScopes.Add(apiScope.ToEntity());
             }
             context.SaveChanges();
         }
    }
}