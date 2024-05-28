using Domain.Entities;

namespace Application.Common.Dtos.OfficesDtos;

public record OfficeReadDto(Guid IdOffice, string Address, string RegistryPhoneNumber, bool IsActive, Guid IdPhoto)
{
    public static OfficeReadDto MapFromOffice(Office office)
    {
        return new OfficeReadDto(office.IdOffice, office.Address, office.RegistryPhoneNumber, office.IsActive, office.IdPhoto);
    }
}