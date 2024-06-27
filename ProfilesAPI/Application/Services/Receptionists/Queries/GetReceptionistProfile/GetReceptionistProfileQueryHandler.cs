using Application.Common;
using Application.Common.Dtos.ReceptionistDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionistProfile;

public class GetReceptionistProfileQueryHandler(IReceptionistsRepo _receptionistsRepo) 
    : IRequestHandler<GetReceptionistProfileQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(GetReceptionistProfileQuery request, CancellationToken cancellationToken)
    {
        var receptionists = await _receptionistsRepo.GetReceptionistById(request.IdReceptionist, cancellationToken);
        if (receptionists == null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ReceptionistNotFound);

        var receptionistDto = GetReceptionistProfileDto.MapFromReceptionist(receptionists);
        return new CustomResult(true, HttpStatusCode.OK, receptionistDto);
    }
}