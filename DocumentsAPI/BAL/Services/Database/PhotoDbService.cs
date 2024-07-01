using System.Net;
using BAL.Common;
using BAL.Common.Dtos.PhotoDtos;
using BAL.Common.Interfaces;
using BAL.Common.ServicesInterfaces;
using DAL.Common.Interfaces.RepoInterfaces;
using DAL.Entities;
using DAL.Events.OfficeEvents;
using Microsoft.Azure.Cosmos;

namespace BAL.Services;

public class PhotoDbService(IPhotoDbRepo _photoDbRepo, IPhotoBlobService _photoBlobService) : IPhotoDbService
{
    public async Task<ICustomResult<string>> GetPhotoUrlById(Guid idPhoto, PhotoTypeEnum type, CancellationToken cancellationToken)
    {
        var photo = await _photoDbRepo.GetPhotoByIdLinked(idPhoto.ToString(),
            new PartitionKey(type.ToString()), cancellationToken);
        if (photo == null)
            return new CustomResult<string>(false, HttpStatusCode.NotFound, messages: [Messages.PhotoNotFound]);
        
        return new CustomResult<string>(true, HttpStatusCode.OK, data: photo.Url);
    }
    public async Task CreatePhoto(CreatePhotoDto createPhotoDto, CancellationToken cancellationToken)
    {
        var photo = new Photo
        {
            IdPhoto = Guid.NewGuid(),
            Url = await _photoBlobService.UploadPhoto(createPhotoDto.Data, cancellationToken),
            IdLinked = createPhotoDto.IdLinked
        };

        await _photoDbRepo.CreatePhoto(photo,
            new PartitionKey(createPhotoDto.Type.ToString()), cancellationToken);
    }
    public async Task UpdatePhoto(UpdatePhotoDto updatePhotoDto, CancellationToken cancellationToken)
    {
        var photo = await _photoDbRepo.GetPhotoByIdLinked(updatePhotoDto.IdLinked.ToString(),
            new PartitionKey(updatePhotoDto.Type.ToString()),cancellationToken);
        if (photo == null) return;
        
        await _photoBlobService.DeletePhoto(photo.Url, cancellationToken);
        photo.Url = await _photoBlobService.UploadPhoto(updatePhotoDto.Data, cancellationToken);
        
        await _photoDbRepo.UpdatePhoto(photo, 
            new PartitionKey(updatePhotoDto.Type.ToString()), cancellationToken);
    }
    public async Task DeletePhoto(DeletePhotoDto deletePhotoDto, CancellationToken cancellationToken)
    {
        var photo = await _photoDbRepo.GetPhotoByIdLinked(deletePhotoDto.IdLinked.ToString(),
            new PartitionKey(deletePhotoDto.Type.ToString()),cancellationToken);
        if (photo == null) return;
        
        await _photoDbRepo.DeletePhoto(photo.IdPhoto.ToString(),
            new PartitionKey(deletePhotoDto.Type.ToString()), cancellationToken);
        await _photoBlobService.DeletePhoto(photo.Url, cancellationToken);
    }
}