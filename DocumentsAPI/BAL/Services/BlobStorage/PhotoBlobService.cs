using BAL.Common.ServicesInterfaces;
using DAL.Common.Interfaces.RepoInterfaces;

namespace BAL.Services;

public class PhotoBlobService(IPhotoBlobRepo _photoBlobRepo) : IPhotoBlobService
{
    public async Task<string> UploadPhoto(byte[] data, CancellationToken cancellationToken)
    {
        var fileName = "photo-" + Guid.NewGuid().ToString() + ".pdf";
        return await _photoBlobRepo.Upload(fileName, data, cancellationToken);
    }
    public async Task DeletePhoto(string url, CancellationToken cancellationToken)
    {
        var uri = new Uri(url);
        var blobName = string.Join("", uri.Segments[2..]);
        await _photoBlobRepo.Delete(blobName, cancellationToken);
    }
}