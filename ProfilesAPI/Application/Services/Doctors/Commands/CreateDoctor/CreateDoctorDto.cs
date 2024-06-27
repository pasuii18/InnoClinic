using Application.Services.DoctorsFolder.Commands.CreateDoctor;
using Domain.Common.Enums;

namespace Application.Common.Dtos.DoctorDtos;

public record CreateDoctorDto(string FirstName, string LastName, string MiddleName, DateTime DateOfBirth,
    int CareerStartYear, DoctorStatus Status, Guid IdAccount, Guid IdSpecialization, string IdOffice)
{
    public CreateDoctorCommand MapInCommand()
    {
        return new CreateDoctorCommand
        {
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            DateOfBirth = DateOfBirth,
            CareerStartYear = CareerStartYear,
            Status = Status,
            IdAccount = IdAccount,
            IdSpecialization = IdSpecialization,
            IdOffice = IdOffice
        };
    }
}