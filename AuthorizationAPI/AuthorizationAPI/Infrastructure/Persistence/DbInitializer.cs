using Domain.Entities;
using Infrastructure.Persistence.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public class DbInitializer
    {
        public static void InitializeDb(AppDbContext context)
        {
            context.Database.EnsureCreated();
        }
        
        public static void InitializeData(
            AppDbContext context, IServiceScope scope)
        {
            AppDbSeeds.InitializeData(context, scope);
        }
    }
}