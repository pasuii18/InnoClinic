using Azure.Storage.Blobs;
using DAL.Common.Options;
using Microsoft.Extensions.Options;

namespace DAL.Common.Clients;

public class AzureBlobClient(IOptions<AzureBlobStorageOptions> options)
    : BlobServiceClient(options.Value.AzureConnectionString);
     
// public class AzureBlobClient(IOptions<AzureBlobStorageOptions> options)
//     : BlobServiceClient(new Uri(options.Value.AzureConnectionString), new DefaultAzureCredential());