using Application.Services.ReceptionistsFolder.Commands.CreateReceptionist;

namespace Application.Common.Dtos.ReceptionistDtos;

public record ReceptionistCreateDto(string FirstName, string LastName, string MiddleName, 
    string Email, Guid IdOffice, Guid IdPhoto)
{
    public CreateReceptionistCommand MapInCommand()
    {
        return new CreateReceptionistCommand
        {
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            Email = Email,
            IdOffice = IdOffice,
            IdPhoto = IdPhoto
        };
    }
}