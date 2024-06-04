using Application.Services.PatientsFolder.Commands.UpdatePatient;

namespace Application.Common.Dtos.PatientDtos;

public record PatientUpdateDto
    (Guid IdPatient, string FirstName, string LastName, string MiddleName, 
        string PhoneNumber, DateTime DateOfBirth, Guid IdPhoto)
{
    public UpdatePatientCommand MapInCommand()
    {
        return new UpdatePatientCommand
        {
            IdPatient = IdPatient,
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            PhoneNumber = PhoneNumber,
            DateOfBirth = DateOfBirth,
            IdPhoto = IdPhoto
        };
    }
}