using Application.Interfaces.RepoInterfaces;
using Dapper;
using Infrastructure.Common.Options;
using Infrastructure.Persistence.Common.MappingHandlers;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
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
            .MappingsConfigure();
        
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