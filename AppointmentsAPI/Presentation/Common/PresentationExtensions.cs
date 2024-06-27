using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application;
using Infrastructure;
using Infrastructure.Common.Options;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common.Converters;
using ServicesAPI.Common.Middlewares;

namespace ServicesAPI.Common;

public static class PresentationExtensions
{
    public static WebApplicationBuilder BuilderConfigure
        (this WebApplicationBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        builder.Configuration
            .AddJsonFile("appsettings.json", false, false)
            .AddJsonFile($"appsettings.{environment}.json", true, false);
        
        builder.Services
            .Configure<PostgresDbOptions>(builder.Configuration.GetSection("ConnectionStrings"))
            .Configure<RabbitMQOptions>(builder.Configuration.GetSection("RabbitMQConfiguration"));

        builder.Services
            .AddApplication()
            .AddInfrastructure();

        builder.Services
            .AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
            .AddJsonOptions(options => options.UseDateAndTimeOnlyJsonConverters());

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return builder;
    }

    private static MvcOptions UseDateOnlyTimeOnlyStringConverters(this MvcOptions options)
    {
        TypeDescriptor.AddAttributes(typeof(DateOnly), new TypeConverterAttribute(typeof(DateOnlyTypeConverter)));
        return options;
    }
    private static JsonOptions UseDateAndTimeOnlyJsonConverters(this JsonOptions options)
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
        return options;
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
}