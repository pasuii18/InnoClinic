using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.EditReceptionist;

public class EditReceptionistCommandHandler : IRequestHandler<EditReceptionistCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(EditReceptionistCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}