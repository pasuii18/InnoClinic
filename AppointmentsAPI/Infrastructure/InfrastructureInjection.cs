using Application.Interfaces.RepoInterfaces;
using Dapper;
using Domain.Events;
using Infrastructure.Common.Options;
using Infrastructure.Consumers;
using Infrastructure.Persistence.Common.MappingHandlers;
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
            .RepositoriesConfigure()
            .MappingsConfigure()
            .MassTransitConfigure();
        
        return services;
    }
    
    private static IServiceCollection MassTransitConfigure
        (this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ServiceUpdateConsumer>();
            x.AddConsumer<DoctorUpdateConsumer>();
            x.AddConsumer<PatientUpdateConsumer>();
            
            x.UsingRabbitMq((context,cfg) =>
            {
                var rabbitMqConfig = context.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
                
                cfg.Host(rabbitMqConfig.HostName, rabbitMqConfig.VirtualHost, h => {
                    h.Username(rabbitMqConfig.UserName);
                    h.Password(rabbitMqConfig.Password);
                });
                
                cfg.ReceiveEndpoint("ServiceUpdateQueue", e =>
                {
                    e.ConfigureConsumer<ServiceUpdateConsumer>(context);
                });
                cfg.ReceiveEndpoint("DoctorUpdateQueue", e =>
                {
                    e.ConfigureConsumer<DoctorUpdateConsumer>(context);
                });
                cfg.ReceiveEndpoint("PatientUpdateQueue", e =>
                {
                    e.ConfigureConsumer<PatientUpdateConsumer>(context);
                });
            
                cfg.ClearSerialization();
                cfg.UseRawJsonSerializer();
                cfg.ConfigureEndpoints(context);
            });
        });
        
        return services;
    }
    private static IServiceCollection DatabaseConfigure(this IServiceCollection services)
    {
        services.AddDbContext<MigrationsDbContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IOptions<PostgresDbOptions>>().Value;
            options.UseNpgsql(connectionString.PostgresConnectionString);
        });
        
        services.AddScoped<AppointmentsDbContext>();
        
        return services;
    }
    private static IServiceCollection RepositoriesConfigure(this IServiceCollection services)
    {
        return services
            .AddScoped<IAppointmentRepo, AppointmentRepo>()
            .AddScoped<IResultRepo, ResultRepo>();
    }
    private static IServiceCollection MappingsConfigure(this IServiceCollection services)
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());
        
        return services;
    }
}