using Domain.Entities;

namespace Application.Common.Dtos.DoctorDtos;

public record GetDoctorProfileDto(Guid IdDoctor, string FirstName, string LastName, string MiddleName,
    int Experience)
{
    public static GetDoctorProfileDto MapFromDoctor(Doctor doctor)
    {
        var exp = DateTime.UtcNow.Year - doctor.CareerStartYear + 1;
        return new GetDoctorProfileDto(doctor.IdDoctor, doctor.FirstName, 
            doctor.LastName, doctor.MiddleName, exp);
    }
}