using Application.Interfaces;
using Application.Interfaces.RepositoryInterfaces;
using Infrastructure.Common.Configs;
using Infrastructure.Common.Options;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection AddInfrastructure
    (this IServiceCollection services, 
        IConfiguration configuration)
    {
        // services.Configure<LoggerOptions>(
        //     configuration.GetSection("Serilog"));
        services.Configure<MongoDbOptions>(
            configuration.GetSection("ConnectionStrings"));
        
        LoggerConfig.ConfigureLogger(configuration);
        services.AddSingleton<CustomMongoDbClient>();
        services.AddScoped<IMongoDbContext, MongoDbContext>();
        services.AddScoped<IOfficesRepo, OfficesRepo>();

        return services;
    }
}