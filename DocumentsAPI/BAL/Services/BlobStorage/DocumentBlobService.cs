using Azure.Storage.Blobs;
using BAL.Common.ServicesInterfaces;
using DAL.Common.Interfaces.RepoInterfaces;

namespace BAL.Services;

public class DocumentBlobService(IDocumentBlobRepo _documentBlobRepo) : IDocumentBlobService
{
    public async Task<string> UploadDocument(byte[] data, CancellationToken cancellationToken)
    {
        var fileName = "document-" + Guid.NewGuid().ToString() + ".pdf";
        return await _documentBlobRepo.Upload(fileName, data, cancellationToken);
    }
    public async Task DeleteDocument(string url, CancellationToken cancellationToken)
    {
        var uri = new Uri(url);
        var blobName = string.Join("", uri.Segments[2..]);
        await _documentBlobRepo.Delete(blobName, cancellationToken);
    }
}