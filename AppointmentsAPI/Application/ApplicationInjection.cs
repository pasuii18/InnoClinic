using System.Reflection;
using Application.Common.Validation;
using Application.Interfaces;
using Application.Services;
using FluentValidation;
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
        return services
            .AddScoped<IAppointmentService, AppointmentService>()
            .AddScoped<IResultService, ResultService>();
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