﻿using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using Application.Services;
using Infrastructure.Common;
using Infrastructure.Common.Options;
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
        services.Configure<RabbitMQOptions>(
            configuration.GetSection("RabbitMQConfiguration"));

        services.AddDbContext<ServiceDbContext>(options
            => options.UseSqlServer(configuration.GetSection("ConnectionStrings").Value));

        services.AddScoped<IServiceRepo, ServiceRepo>();
        services.AddScoped<IServiceCategoryRepo, ServiceCategoryRepo>();
        services.AddScoped<ISpecializationRepo, SpecializationRepo>();

        services.AddSingleton<RabbitMQClient>();
        services.AddScoped<IMessageProducer, MessageProducer>();
        return services;
    }
}