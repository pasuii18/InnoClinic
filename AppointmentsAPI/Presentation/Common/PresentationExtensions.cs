using Application;
using Infrastructure;
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
            .AddApplication()
            .AddInfrastructure();

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
}