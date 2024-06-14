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
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation(cfg =>
        {
            cfg.DisableBuiltInModelValidation = true;
            cfg.ValidationStrategy = ValidationStrategy.All;
            cfg.EnableCustomBindingSourceAutomaticValidation = true;
            cfg.OverrideDefaultResultFactoryWith<CustomValidationResultFactory>();
        });
        
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        services.AddScoped<ISpecializationService, SpecializationService>();
        return services;
    }
}