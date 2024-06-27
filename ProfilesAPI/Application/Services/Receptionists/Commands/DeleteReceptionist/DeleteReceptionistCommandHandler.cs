using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.ReceptionistsFolder.Commands.DeleteReceptionist;

public class DeleteReceptionistCommandHandler(IReceptionistsRepo _receptionistsRepo)
    : IRequestHandler<DeleteReceptionistCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
    {
        var receptionist = await _receptionistsRepo.GetReceptionistById(request.IdReceptionist, cancellationToken);
        if (receptionist == null)
            return new CustomResult(false, HttpStatusCode.NotFound);

        await _receptionistsRepo.DeleteReceptionist(request.IdReceptionist, cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
}