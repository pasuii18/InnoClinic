using System.Reflection;
using Application.Common.Mappings;
using Application.Common.Validation;
using Application.Interfaces;
using Application.Services;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Enums;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Application;

public static class ApplicationInjection
{
    public static IServiceCollection AddApplication
        (this IServiceCollection services)
    {
        return services
            .ServicesConfigure()
            .ValidationConfigure();
    }
    
    private static IServiceCollection ServicesConfigure
        (this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(MapsterProfile).Assembly);
        
        return services
            .AddScoped<IAppointmentService, AppointmentService>()
            .AddScoped<IResultService, ResultService>()
            .AddScoped<IProcessesService, ProcessService>();
    }
    
    private static IServiceCollection ValidationConfigure
        (this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddFluentValidationAutoValidation(configuration =>
            {
                configuration.DisableBuiltInModelValidation = true;
                configuration.ValidationStrategy = ValidationStrategy.All;
                configuration.EnableCustomBindingSourceAutomaticValidation = true;

                configuration.OverrideDefaultResultFactoryWith<CustomValidationResultFactory>();
            });
    }
}