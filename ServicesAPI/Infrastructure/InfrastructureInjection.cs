using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using Application.Services;
using Infrastructure.Common;
using Infrastructure.Common.Options;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using MassTransit;
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
            .DatabaseConfigure()
            .MassTransitConfigure();
        
        return services;
    }

    private static IServiceCollection DatabaseConfigure(this IServiceCollection services)
    {
        services.AddDbContext<ServiceDbContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IOptions<SqlServerDbOptions>>().Value;
            options.UseSqlServer(connectionString.SqlServerConnectionString);
        });

        services
            .AddScoped<IServiceRepo, ServiceRepo>()
            .AddScoped<IServiceCategoryRepo, ServiceCategoryRepo>()
            .AddScoped<ISpecializationRepo, SpecializationRepo>();
        
        return services;
    }
    private static IServiceCollection MassTransitConfigure(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            
            x.UsingRabbitMq((context,cfg) =>
            {
                var rabbitMqConfig = context.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
                
                cfg.Host(rabbitMqConfig.HostName, rabbitMqConfig.VirtualHost, h => {
                    h.Username(rabbitMqConfig.UserName);
                    h.Password(rabbitMqConfig.Password);
                });

                cfg.ClearSerialization();
                cfg.UseRawJsonSerializer();
                cfg.ConfigureEndpoints(context);
            });
        });
        
        return services;
    }
}