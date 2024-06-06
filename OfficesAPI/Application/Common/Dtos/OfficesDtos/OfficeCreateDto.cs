using Domain.Entities;
using MongoDB.Bson;

namespace Application.Common.Dtos.OfficesDtos;

public record OfficeCreateDto(string Address, string RegistryPhoneNumber, bool IsActive, Guid IdPhoto)
{
    public static Office MapInOffice(OfficeCreateDto model)
    {
        return new Office
        {
            IdOffice = ObjectId.GenerateNewId(DateTime.Now),
            Address = model.Address,
            RegistryPhoneNumber = model.RegistryPhoneNumber,
            IsActive = model.IsActive,
            IdPhoto = model.IdPhoto
        };
    }
}