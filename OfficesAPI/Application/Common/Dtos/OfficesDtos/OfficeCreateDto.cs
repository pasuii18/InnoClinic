using Domain.Entities;

namespace Application.Common.Dtos.OfficesDtos;

public record OfficeCreateDto(string Address, string RegistryPhoneNumber, bool IsActive, Guid IdPhoto)
{
    public static Office MapInOffice(OfficeCreateDto model)
    {
        return new Office
        {
            IdOffice = Guid.NewGuid(),
            Address = model.Address,
            RegistryPhoneNumber = model.RegistryPhoneNumber,
            IsActive = model.IsActive,
            IdPhoto = model.IdPhoto
        };
    }
}