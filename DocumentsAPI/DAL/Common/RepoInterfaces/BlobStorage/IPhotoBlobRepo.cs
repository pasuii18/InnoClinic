namespace DAL.Common.Interfaces.RepoInterfaces;

public interface IPhotoBlobRepo
{
    public Task<string> Upload(string fileName, byte[] data, CancellationToken cancellationToken);
    public Task Delete(string blobName, CancellationToken cancellationToken);
}