using Application.Services.PatientsFolder.Commands.CreatePatient;

namespace Application.Common.Dtos.PatientDtos;

public record PatientCreateDto
(string FirstName, string LastName, string MiddleName, 
    string PhoneNumber, bool IsLinkedToAccount, DateTime DateOfBirth, Guid IdPhoto)
{
    public CreatePatientCommand MapInCommand()
    {
        return new CreatePatientCommand
        {
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            PhoneNumber = PhoneNumber,
            IsLinkedToAccount = IsLinkedToAccount,
            DateOfBirth = DateOfBirth,
            IdPhoto = IdPhoto
        };
    }
}