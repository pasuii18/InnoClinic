using Application.Services.DoctorsFolder.Commands.UpdateDoctor;
using Domain.Common.Enums;

namespace Application.Common.Dtos.DoctorDtos;

public record DoctorUpdateDto(Guid IdDoctor, string FirstName, string LastName, string MiddleName, DateTime DateOfBirth,
    int CareerStartYear, DoctorStatus Status, Guid IdSpecialization, string IdOffice)
{
    public UpdateDoctorCommand MapInCommand()
    {
        return new UpdateDoctorCommand
        {
            IdDoctor = IdDoctor,
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            DateOfBirth = DateOfBirth,
            CareerStartYear = CareerStartYear,
            Status = Status,
            IdSpecialization = IdSpecialization,
            IdOffice = IdOffice
        };
    }
}