using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Configs;

public static class DBConfig
{
    public static IServiceCollection ConfigureDb
        (this IServiceCollection services, string connectionString)
    {
        // var sqlServerConnectionString = new SqlConnectionStringBuilder(connectionString)
        // {
        //     UserID = "sa",
        //     Password = "pa55w0rd!"
        // };
        
        services.AddDbContext<AppDbContext>(config =>
        {
            // config.UseSqlServer(connectionString);
            config.UseInMemoryDatabase("Memory");
        });

        return services;
    }
}