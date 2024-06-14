using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Common.Validation;
using Application.Interfaces;
using Application.Interfaces.ServicesInterfaces;
using Application.Services;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Enums;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Application;

public static class ApplicationInjection
{
    public static IServiceCollection AddApplication
        (this IServiceCollection services)
    {
        services
            .ValidationConfigure()
            .ServicesConfigure();
        
        return services;
    }
    
    private static IServiceCollection ValidationConfigure(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableBuiltInModelValidation = true;
                cfg.ValidationStrategy = ValidationStrategy.All;
                cfg.EnableCustomBindingSourceAutomaticValidation = true;
                cfg.OverrideDefaultResultFactoryWith<CustomValidationResultFactory>();
            });
        
        return services;
    }
    private static IServiceCollection ServicesConfigure(this IServiceCollection services)
    {
        services
            .AddScoped<IServiceService, ServiceService>()
            .AddScoped<IServiceCategoryService, ServiceCategoryService>()
            .AddScoped<ISpecializationService, SpecializationService>();
        
        return services;
    }
}