using Application.Interfaces.ReposInterfaces;
using Infrastructure.Persistence.Common.Options;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection AddInfrastructure
    (this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<SqlServerDbOptions>(
            configuration.GetSection("ConnectionStrings")); // not working sopmehow xd
        
        services.AddDbContext<MigrationsDbContext>(options =>
            options.UseSqlServer(configuration.GetSection("ConnectionStrings").Value));

        services.AddScoped<IPatientsRepo, PatientsRepo>();
        
        return services;
    }
}