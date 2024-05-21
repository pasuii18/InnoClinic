using Infrastructure.Persistence.Seeds;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence
{
    public class DbInitializer
    {
        public static void InitializeDb(AppDbContext context)
        {
            context.Database.EnsureCreated();
        }
        
        public static void InitializeData(
            AppDbContext context, UserManager<IdentityUser> userManager)
        {
            AppDbSeeds.InitializeData(context, userManager);
        }
    }
}