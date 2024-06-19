using Application.Common.Dtos.AppointmentsDtos;
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationInjection
{
    public static IServiceCollection AddApplication
        (this IServiceCollection services)
    {
        return services
            .ServicesConfigure();
    }
    
    private static IServiceCollection ServicesConfigure
        (this IServiceCollection services)
    {
        return services
            .AddScoped<IAppointmentService, AppointmentService>()
            .AddScoped<IResultService, ResultService>();
    }
}