using Infrastructure.Common.Options;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection AddInfrastructure
        (this IServiceCollection services)
    {
        services
            .DatabaseConfigure();
        
        return services;
    }
    
    private static IServiceCollection DatabaseConfigure(this IServiceCollection services)
    {
        services.AddDbContext<AppointmentsDbContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IOptions<PostgresDbOptions>>().Value;
            options.UseNpgsql(connectionString.PostgresConnectionString);
        });
        
        return services;
    }
}