using Application.Common;
using Application.Common.Dtos.PatientDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.PatientsFolder.Queries.ViewPatients;

public class GetPatientsQueryHandler(IPatientsRepo _patientsRepo) : IRequestHandler<GetPatientsQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientsRepo.GetPatients(
            request.PatientFilters, request.PageSettings, cancellationToken);
        
        var patientsDto = GetPatientsDto.MapFromPatients(patients);
        return new CustomResult(true, HttpStatusCode.OK, patientsDto);
    }
}