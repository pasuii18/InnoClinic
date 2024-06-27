using Application.Services.PatientsFolder.Commands.CreatePatient;

namespace Application.Common.Dtos.PatientDtos;

public record CreatePatientDto
(string FirstName, string LastName, string MiddleName, 
    bool IsLinkedToAccount, DateTime DateOfBirth)
{
    public CreatePatientCommand MapInCommand()
    {
        return new CreatePatientCommand
        {
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            IsLinkedToAccount = IsLinkedToAccount,
            DateOfBirth = DateOfBirth,
        };
    }
}