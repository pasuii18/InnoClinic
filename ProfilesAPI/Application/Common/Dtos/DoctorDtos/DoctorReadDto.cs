using Domain;
using Domain.Entities;

namespace Application.Common.Dtos.DoctorDtos;

public record DoctorReadDto(Guid IdDoctor, string FirstName, string LastName, string MiddleName,
    int Experience)
{
    public static DoctorReadDto MapFromDoctor(Doctor doctor)
    {
        var exp = DateTime.UtcNow.Year - doctor.CareerStartYear + 1;
        return new DoctorReadDto(doctor.IdDoctor, doctor.FirstName, 
            doctor.LastName, doctor.MiddleName, exp);
    }
}