using Application.Services.DoctorsFolder.Commands.CreateDoctor;
using Domain.Common.Enums;

namespace Application.Common.Dtos.DoctorDtos;

public record DoctorCreateDto(string FirstName, string LastName, string MiddleName, DateTime DateOfBirth,
    string Email, int CareerStartYear, DoctorStatus Status, Guid IdAccount, Guid IdSpecialization, Guid IdOffice)
{
    public CreateDoctorCommand MapInCommand()
    {
        return new CreateDoctorCommand
        {
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            DateOfBirth = DateOfBirth,
            Email = Email,
            CareerStartYear = CareerStartYear,
            Status = Status,
            IdAccount = IdAccount,
            IdSpecialization = IdSpecialization,
            IdOffice = IdOffice
        };
    }
}