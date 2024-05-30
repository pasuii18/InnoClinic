using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.CreateReceptionist;

public class CreateReceptionistCommandHandler : IRequestHandler<CreateReceptionistCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(CreateReceptionistCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}