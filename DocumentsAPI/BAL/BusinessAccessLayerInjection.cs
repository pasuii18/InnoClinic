using Microsoft.Extensions.DependencyInjection;

namespace BAL;

public static class BusinessAccessLayerInjection
{
    public static IServiceCollection AddBusinessAccessLayer
        (this IServiceCollection services)
    {
        return services
            .ServicesConfigure();
    }
    private static IServiceCollection ServicesConfigure
        (this IServiceCollection services)
    {
        return services;
    }
}