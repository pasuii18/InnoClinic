using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.CreateReceptionist;

public class CreateReceptionistCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string IdOffice { get; set; }

    public static Receptionist MapInReceptionist(CreateReceptionistCommand command)
    {
        return new Receptionist
        {
            IdReceptionist = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            MiddleName = command.MiddleName,
            IdOffice = command.IdOffice,
        };
    }
}