using Azure.Storage.Blobs;
using DAL.Common.Clients;

namespace DAL.Common.Contexts;

public class AzureBlobContext(AzureBlobClient _client)
{
    public BlobContainerClient DocumentsContainerClient { get; set; } = _client.GetBlobContainerClient("documents");
    public BlobContainerClient PhotosContainerClient { get; set; } = _client.GetBlobContainerClient("photos");
}
