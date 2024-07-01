namespace BAL.Common.ServicesInterfaces;

public interface IDocumentBlobService
{
    public Task<string> UploadDocument(byte[] data, CancellationToken cancellationToken);
    public Task DeleteDocument(string url, CancellationToken cancellationToken);
}