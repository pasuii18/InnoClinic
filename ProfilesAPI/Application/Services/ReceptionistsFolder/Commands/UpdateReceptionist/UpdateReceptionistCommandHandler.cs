using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.ReceptionistsFolder.Commands.UpdateReceptionist;

public class UpdateReceptionistCommandHandler(IReceptionistsRepo _receptionistsRepo)
    : IRequestHandler<UpdateReceptionistCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(UpdateReceptionistCommand request, CancellationToken cancellationToken)
    {
        var receptionist = await _receptionistsRepo.GetReceptionistById(request.IdReceptionist, cancellationToken);
        if (receptionist == null)
            return new CustomResult(false, Messages.ReceptionistNotFound, HttpStatusCode.NotFound);

        request.MapInReceptionist(receptionist);
        await _receptionistsRepo.UpdateReceptionist(receptionist, cancellationToken);
        
        return new CustomResult(true, Messages.ReceptionistUpdated, HttpStatusCode.OK);
    }
}