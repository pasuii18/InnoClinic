using Application.Common;
using Application.Interfaces;
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
            configuration.GetSection("ConnectionStrings"));
        
        services.AddDbContext<MigrationsDbContext>(options =>
            options.UseSqlServer(configuration.GetSection("ConnectionStrings").Value));

        services.AddScoped<ProfilesDbContext>();
        
        services.AddScoped<IPatientsRepo, PatientsRepo>();
        services.AddScoped<IDoctorsRepo, DoctorsRepo>();
        services.AddScoped<IReceptionistsRepo, ReceptionistsRepo>();
        
        services.AddTransient<ICustomResult, CustomResult>();
        
        return services;
    }
}