using Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Configs;

public static class DbConfig
{
    public static IServiceCollection ConfigureDb
        (this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(config =>
        {
            config.UseSqlServer(connectionString);
        });

        return services;
    }
}