using Application.Services.ReceptionistsFolder.Commands.UpdateReceptionist;

namespace Application.Common.Dtos.ReceptionistDtos;

public record ReceptionistUpdateDto(Guid IdReceptionist, string FirstName, string LastName, string MiddleName, 
    Guid IdOffice)
{
    public UpdateReceptionistCommand MapInCommand()
    {
        return new UpdateReceptionistCommand
        {
            IdReceptionist = IdReceptionist,
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            IdOffice = IdOffice,
        };
    }
}