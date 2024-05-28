using System.Reflection;
using Application.Common.Validation;
using Application.Interfaces.ServicesInterfaces;
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
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;
            configuration.ValidationStrategy = ValidationStrategy.All;
            configuration.EnableCustomBindingSourceAutomaticValidation = true;

            configuration.OverrideDefaultResultFactoryWith<CustomValidationResultFactory>();
        });

        services.AddScoped<IOfficesService, OfficesService>();
        
        return services;
    }
}