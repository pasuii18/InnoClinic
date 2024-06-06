using Infrastructure.Common.Configs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection AddInfrastructure
        (this IServiceCollection services, 
            IWebHostEnvironment environment,
            IConfiguration configuration)
    {
        services.ConfigureDb(configuration.GetConnectionString("DbConnection"));
        services.ConfigureIdentityServer(environment, configuration.GetConnectionString("DbConnection"));
        services.ConfigureCors();

        return services;
    }
}