using System.Reflection;
using Application.Common.Interfaces.RepositoryInterfaces;
using Application.Common.Validators;
using Application.Services;
using Domain.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication
        (this IServiceCollection services)
    {
        services.AddScoped<IOfficesService, OfficesService>();
        
        services.AddValidatorsFromAssemblyContaining<OfficeCreateValidator>();
        services.AddValidatorsFromAssemblyContaining<OfficeUpdateValidator>();

        return services;
    }
}