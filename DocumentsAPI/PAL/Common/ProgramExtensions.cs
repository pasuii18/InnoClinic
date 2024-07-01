using BAL;
using DAL;
using DAL.Common;
using DAL.Common.Options;
using MassTransit;
using Microsoft.Extensions.Options;
using Presentation.Common.Middlewares;
using Presentation.Consumers;
using Presentation.Consumers.AccountConsumers;

namespace Presentation.Common;

public static class ProgramExtensions
{
    public static WebApplicationBuilder BuilderConfigure
        (this WebApplicationBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        builder.Configuration
            .AddJsonFile("appsettings.json", false, false)
            .AddJsonFile($"appsettings.{environment}.json", true, false);

        builder.Services
            .Configure<AzureBlobStorageOptions>(builder.Configuration.GetSection("AzureBlobStorage"))
            .Configure<CosmosDbOptions>(builder.Configuration.GetSection("AzureCosmosDb"))
            .Configure<RabbitMQOptions>(builder.Configuration.GetSection("RabbitMQConfiguration"));
            
        builder.Services
            .AddDataAccessLayer()
            .AddBusinessAccessLayer()
            .MassTransitConfigure();
        
        builder.Services
            .AddControllers();
        
        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
        
        return builder;
    }
    public static WebApplication ApplicationConfigure(this WebApplication app)
    {
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        
        return app;
    }
    public static async Task RunApplicationAsync(this WebApplication app)
    {
        await app.RunAsync();
    }
    private static IServiceCollection MassTransitConfigure
        (this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.ConsumersConfigure();
            
            x.UsingRabbitMq((context,cfg) =>
            {
                var rabbitMqConfig = context.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
                
                cfg.Host(rabbitMqConfig.HostName, rabbitMqConfig.VirtualHost, h => {
                    h.Username(rabbitMqConfig.UserName);
                    h.Password(rabbitMqConfig.Password);
                });

                // cfg.EndpointsConfigure(context);
            
                cfg.ClearSerialization();
                cfg.UseRawJsonSerializer();
                cfg.ConfigureEndpoints(context, 
                    new DefaultEndpointNameFormatter(prefix: "Queue", includeNamespace: false));
            });
        });
        
        return services;
    }
    private static IBusRegistrationConfigurator ConsumersConfigure
        (this IBusRegistrationConfigurator configurator)
    {
        configurator.AddConsumer<ResultConsumer>();
        configurator.AddConsumer<OfficeConsumer>();
        configurator.AddConsumer<AccountConsumer>();

        return configurator;
    }
    private static IRabbitMqBusFactoryConfigurator EndpointsConfigure
        (this IRabbitMqBusFactoryConfigurator configurator, IBusRegistrationContext context)
    {
        configurator.ReceiveEndpoint("CreatedResultQueue", e =>
        {
            e.ConfigureConsumer<ResultConsumer>(context);
        });

        return configurator;
    }
}