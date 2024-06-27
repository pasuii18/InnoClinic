using Application.Services.ReceptionistsFolder.Commands.CreateReceptionist;

namespace Application.Common.Dtos.ReceptionistDtos;

public record CreateReceptionistDto(string FirstName, string LastName, string MiddleName, string IdOffice)
{
    public CreateReceptionistCommand MapInCommand()
    {
        return new CreateReceptionistCommand
        {
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            IdOffice = IdOffice,
        };
    }
}