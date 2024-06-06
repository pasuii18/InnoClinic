using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.ReceptionistsFolder.Commands.CreateReceptionist;

public class CreateReceptionistCommandHandler(IReceptionistsRepo _receptionistsRepo)
    : IRequestHandler<CreateReceptionistCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(CreateReceptionistCommand request, CancellationToken cancellationToken)
    {
        var receptionist = CreateReceptionistCommand.MapInReceptionist(request);
        await _receptionistsRepo.CreateReceptionist(receptionist, cancellationToken);
        
        return new CustomResult(true, HttpStatusCode.OK, receptionist.IdReceptionist);
    }
}