using Domain.Entities;

namespace Application.Common.Dtos.ReceptionistDtos;

public record ReceptionistReadDto(Guid IdReceptionist, string FirstName, string LastName, string MiddleName)
{
    public static ReceptionistReadDto MapFromReceptionist(Receptionist rec)
    {
        return new ReceptionistReadDto(rec.IdReceptionist, rec.FirstName, rec.LastName, rec.MiddleName);
    }
}