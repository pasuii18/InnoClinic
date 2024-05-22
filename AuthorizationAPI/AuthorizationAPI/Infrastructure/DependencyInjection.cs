using Infrastructure.Common.Configs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure
        (this IServiceCollection services, 
            IWebHostEnvironment environment,
            IConfiguration configuration)
    {
        var conString = configuration.GetConnectionString("DbConnection");
        var sqlServerConnectionString = new SqlConnectionStringBuilder(conString) // fix: user secrets
        {
            UserID = "sa",
            Password = "pa55w0rd!"
        };
        
        services.ConfigureDb(sqlServerConnectionString.ConnectionString);
        services.ConfigureIdentityServer(environment, sqlServerConnectionString.ConnectionString);
        services.ConfigureCors();
        services.ConfigureServices();

        return services;
    }
}