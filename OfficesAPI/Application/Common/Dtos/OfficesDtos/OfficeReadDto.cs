using Domain.Entities;
using MongoDB.Bson;

namespace Application.Common.Dtos.OfficesDtos;

public record OfficeReadDto(string IdOffice, string Address, string RegistryPhoneNumber, bool IsActive, Guid IdPhoto)
{
    public static OfficeReadDto MapFromOffice(Office office)
    {
        return new OfficeReadDto(office.IdOffice.ToString(),
            office.Address, office.RegistryPhoneNumber, office.IsActive, office.IdPhoto);
    }
}