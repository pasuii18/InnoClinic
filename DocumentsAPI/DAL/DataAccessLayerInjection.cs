using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DataAccessLayerInjection
{
    public static IServiceCollection AddDataAccessLayer
        (this IServiceCollection services)
    {
        return services;
    }
}