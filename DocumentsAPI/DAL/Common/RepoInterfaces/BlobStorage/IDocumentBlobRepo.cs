namespace DAL.Common.Interfaces.RepoInterfaces;

public interface IDocumentBlobRepo
{
    public Task<string> Upload(string fileName, byte[] data, CancellationToken cancellationToken);
    public Task Delete(string blobName, CancellationToken cancellationToken);
}