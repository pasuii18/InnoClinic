using Azure.Storage.Sas;
using DAL.Common.Clients;
using DAL.Common.Contexts;
using DAL.Common.Interfaces.RepoInterfaces;

namespace DAL.Repos;

public class PhotoBlobRepo(AzureBlobContext _context) : IPhotoBlobRepo
{
    public async Task<string> Upload(string fileName, byte[] data, CancellationToken cancellationToken)
    {
        var blobClient = _context.PhotosContainerClient.GetBlobClient(fileName);
        using (var memoryStream = new MemoryStream(data))
        {
            await blobClient.UploadAsync(memoryStream, true, cancellationToken);
        }
        return CreateSasUri(fileName, _context.PhotosContainerClient.Name, cancellationToken).ToString();
    }
    public async Task Delete(string blobName, CancellationToken cancellationToken)
    {
        var blobClient = _context.PhotosContainerClient.GetBlobClient(blobName);

        await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
    }
    private Uri CreateSasUri(string blobName, string containerName, CancellationToken cancellationToken)
    {
        var blobClient = _context.PhotosContainerClient.GetBlobClient(blobName);

        var sasBuilder = new BlobSasBuilder
        {
            BlobContainerName = containerName,
            BlobName = blobName,
            Resource = "b",
            StartsOn = DateTimeOffset.UtcNow
        };
        sasBuilder.SetPermissions(BlobSasPermissions.Read);

        return blobClient.GenerateSasUri(sasBuilder);
    }
}