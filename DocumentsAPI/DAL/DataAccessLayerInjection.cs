using DAL.Common.Clients;
using DAL.Common.Contexts;
using DAL.Common.Interfaces.RepoInterfaces;
using DAL.Repos;
using DAL.Repos.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DataAccessLayerInjection
{
    public static IServiceCollection AddDataAccessLayer
        (this IServiceCollection services)
    {
        return services
            .AzureBlobConfigure()
            .CosmosDbConfigure();
    }
    
    private static IServiceCollection AzureBlobConfigure
        (this IServiceCollection services)
    {
        return services
            .AddScoped<IDocumentBlobRepo, DocumentBlobRepo>()
            .AddScoped<IPhotoBlobRepo, PhotoBlobRepo>()
            .AddSingleton<AzureBlobClient>()
            .AddScoped<AzureBlobContext>();
    }
    private static IServiceCollection CosmosDbConfigure
        (this IServiceCollection services)
    {
        return services
            .AddScoped<IDocumentDbRepo, DocumentDbRepo>()
            .AddScoped<IPhotoDbRepo, PhotoDbRepo>()
            .AddSingleton<CosmosDbClient>()
            .AddScoped<CosmosDbContext>();
    }
}