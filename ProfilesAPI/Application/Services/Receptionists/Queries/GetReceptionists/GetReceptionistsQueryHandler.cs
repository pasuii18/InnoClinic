using Application.Common;
using Application.Common.Dtos.ReceptionistDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionists;

public class GetReceptionistsQueryHandler(IReceptionistsRepo _receptionistsRepo) 
    : IRequestHandler<GetReceptionistsQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(GetReceptionistsQuery request, CancellationToken cancellationToken)
    {
        var receptionists = await _receptionistsRepo.GetReceptionists(
            request.ReceptionistFilters, request.PageSettings, cancellationToken);
        
        var receptionistsDto = GetReceptionistsDto.MapFromReceptionist(receptionists);
        return new CustomResult(true, HttpStatusCode.OK, receptionistsDto);
    }
}