using Application.Common;
using Application.Common.Dtos.ReceptionistDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionistProfile;

public class ViewReceptionistProfileQueryHandler(IReceptionistsRepo _receptionistsRepo) 
    : IRequestHandler<ViewReceptionistProfileQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(ViewReceptionistProfileQuery request, CancellationToken cancellationToken)
    {
        var receptionists = await _receptionistsRepo.GetReceptionistById(request.IdReceptionist, cancellationToken);
        if (receptionists == null)
            return new CustomResult(false, Messages.ReceptionistNotFound, HttpStatusCode.NotFound);

        var receptionistDto = ReceptionistReadDto.MapFromReceptionist(receptionists);
        return new CustomResult(true, Messages.Success, HttpStatusCode.OK, receptionistDto);
    }
}