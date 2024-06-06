using Application.Common;
using Application.Common.Dtos.ReceptionistDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionists;

public class ViewReceptionistsQueryHandler(IReceptionistsRepo _receptionistsRepo) 
    : IRequestHandler<ViewReceptionistsQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(ViewReceptionistsQuery request, CancellationToken cancellationToken)
    {
        var receptionists = await _receptionistsRepo.GetReceptionists(
            request.ReceptionistFilters, request.PageSettings, cancellationToken);
        
        var receptionistDto = receptionists.Select(ReceptionistReadDto.MapFromReceptionist).ToList().AsReadOnly();
        return new CustomResult(true, HttpStatusCode.OK, receptionistDto);
    }
}