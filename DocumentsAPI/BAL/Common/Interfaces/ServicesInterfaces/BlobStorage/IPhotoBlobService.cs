namespace BAL.Common.ServicesInterfaces;

public interface IPhotoBlobService
{
    public Task<string> UploadPhoto(byte[] data, CancellationToken cancellationToken);
    public Task DeletePhoto(string url, CancellationToken cancellationToken);
}