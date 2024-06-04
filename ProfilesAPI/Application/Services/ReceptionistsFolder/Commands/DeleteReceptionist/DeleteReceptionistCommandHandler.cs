using System.Net;
using Application.Common;
using Application.Common.Dtos.ReceptionistDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.DeleteReceptionist;

public class DeleteReceptionistCommandHandler(IReceptionistsRepo _receptionistsRepo)
    : IRequestHandler<DeleteReceptionistCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
    {
        var receptionist = await _receptionistsRepo.GetReceptionistById(request.IdReceptionist, cancellationToken);
        if (receptionist == null)
            return new CustomResult(false, Messages.ReceptionistNotFound, HttpStatusCode.NotFound);

        await _receptionistsRepo.DeleteReceptionist(request.IdReceptionist, cancellationToken);
        return new CustomResult(true, Messages.ReceptionistDeleted, HttpStatusCode.OK);
    }
}