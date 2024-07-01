using BAL.Common.Dtos.PhotoDtos;
using BAL.Common.Interfaces;
using DAL.Entities;
using DAL.Events.OfficeEvents;

namespace BAL.Common.ServicesInterfaces;

public interface IPhotoDbService
{
    public Task<ICustomResult<string>> GetPhotoUrlById(Guid idPhoto, PhotoTypeEnum type, CancellationToken cancellationToken);
    public Task CreatePhoto(CreatePhotoDto createPhotoDto, CancellationToken cancellationToken);
    public Task UpdatePhoto(UpdatePhotoDto updatePhotoDto, CancellationToken cancellationToken);
    public Task DeletePhoto(DeletePhotoDto deletePhotoDto, CancellationToken cancellationToken);
}