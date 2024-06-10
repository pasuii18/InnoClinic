using Application.Interfaces.ServicesInterfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationInjection
{
    public static IServiceCollection AddApplication
        (this IServiceCollection services)
    {
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        services.AddScoped<ISpecializationService, SpecializationService>();
        return services;
    }
}