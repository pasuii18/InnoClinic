using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.UpdateReceptionist;

public class UpdateReceptionistCommand : IRequest<ICustomResult>
{
    public Guid IdReceptionist { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Guid IdOffice { get; set; }

    public void MapInReceptionist(Receptionist rec)
    {
        rec.FirstName = FirstName;
        rec.LastName = LastName;
        rec.MiddleName = MiddleName;
        rec.IdOffice = IdOffice;
    }
}