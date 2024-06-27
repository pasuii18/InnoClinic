using Domain.Entities;

namespace Application.Common.Dtos.ReceptionistDtos;

public record GetReceptionistProfileDto(Guid IdReceptionist, string FirstName, string LastName, string MiddleName)
{
    public static GetReceptionistProfileDto MapFromReceptionist(Receptionist rec)
    {
        return new GetReceptionistProfileDto(rec.IdReceptionist, rec.FirstName, rec.LastName, rec.MiddleName);
    }
}