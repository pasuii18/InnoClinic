using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.DeleteReceptionist;

public class DeleteReceptionistCommand : IRequest<ICustomResult>
{
    public Guid IdReceptionist { get; set; }
}