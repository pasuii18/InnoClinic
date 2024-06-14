using Application;
using Infrastructure;
using Infrastructure.Common.Options;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
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
            .Configure<SqlServerDbOptions>(builder.Configuration.GetSection("ConnectionStrings"))
            .Configure<RabbitMQOptions>(builder.Configuration.GetSection("RabbitMQConfiguration"));
            
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
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();
        
        context.Database.EnsureCreated();
        await context.Database.MigrateAsync();
        
        await app.RunAsync();
    }
}