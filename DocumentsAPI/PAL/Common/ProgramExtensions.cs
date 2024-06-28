using BAL;
using DAL;
using DAL.Common;
using Presentation.Common.Middlewares;

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
            .Configure<CosmosDbOptions>(builder.Configuration.GetSection("AzureCosmosDb"));
            
        builder.Services
            .AddDataAccessLayer()
            .AddBusinessAccessLayer();
        
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