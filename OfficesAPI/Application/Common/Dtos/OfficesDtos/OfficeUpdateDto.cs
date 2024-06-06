using Domain.Entities;
using MongoDB.Bson;

namespace Application.Common.Dtos.OfficesDtos;

public record OfficeUpdateDto(string IdOffice, string Address, string RegistryPhoneNumber, bool IsActive, Guid IdPhoto)
{
    public static Office MapInOffice(OfficeUpdateDto model)
    {
        return new Office
        {
            Address = model.Address,
            RegistryPhoneNumber = model.RegistryPhoneNumber,
            IsActive = model.IsActive,
            IdPhoto = model.IdPhoto
        };
    }
}