using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.EditReceptionist;

public class EditReceptionistCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Guid IdOffice { get; set; }
    public Guid IdPhoto { get; set; }
}