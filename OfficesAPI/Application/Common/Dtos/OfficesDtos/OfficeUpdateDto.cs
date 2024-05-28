using Domain.Entities;

namespace Application.Common.Dtos.OfficesDtos;

public record OfficeUpdateDto(Guid IdOffice, string Address, string RegistryPhoneNumber, bool IsActive, Guid IdPhoto)
{
    public static Office MapInOffice(OfficeUpdateDto model)
    {
        return new Office
        {
            IdOffice = model.IdOffice,
            Address = model.Address,
            RegistryPhoneNumber = model.RegistryPhoneNumber,
            IsActive = model.IsActive,
            IdPhoto = model.IdPhoto
        };
    }
}