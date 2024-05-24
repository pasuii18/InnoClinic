using Application.Common.Interfaces;
using Application.Common.Interfaces.RepositoryInterfaces;
using Application.Services;
using Domain.Common.Interfaces;
using Infrastructure.Common.Configs;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure
    (this IServiceCollection services, 
        IConfiguration configuration)
    {
        LoggerConfig.ConfigureLogger(configuration);
        services.AddSingleton<IMongoDbContext, MongoDbContext>();
        services.AddScoped<IOfficesRepo, OfficesRepo>();

        return services;
    }
}