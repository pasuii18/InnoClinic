using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Configs;

public static class CorsConfig
{
    public static IServiceCollection ConfigureCors(
        this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("https://localhost:44323")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        return services;
    }
}