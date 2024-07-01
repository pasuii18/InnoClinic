using DAL.Common.Clients;
using Microsoft.Azure.Cosmos;

namespace DAL.Common.Contexts;

public class CosmosDbContext
{
    public Container PhotosContainer;
    public Container DocumentsContainer;
    
    public CosmosDbContext(CosmosDbClient client)
    {
        var database = client.GetDatabase("DocumentsAPI");
        PhotosContainer = database.GetContainer("photos");
        DocumentsContainer = database.GetContainer("documents");
    }
}