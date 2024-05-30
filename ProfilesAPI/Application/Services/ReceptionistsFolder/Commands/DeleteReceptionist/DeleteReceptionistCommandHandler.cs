using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.DeleteReceptionist;

public class DeleteReceptionistCommandHandler : IRequestHandler<DeleteReceptionistCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}