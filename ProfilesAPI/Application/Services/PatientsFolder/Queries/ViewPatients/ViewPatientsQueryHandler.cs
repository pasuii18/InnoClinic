using Application.Common;
using Application.Common.Dtos.PatientDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.PatientsFolder.Queries.ViewPatients;

public class ViewPatientsQueryHandler(IPatientsRepo _patientsRepo) : IRequestHandler<ViewPatientsQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(ViewPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientsRepo.GetPatients(
            request.PatientFilters, request.PageSettings, cancellationToken);
        
        var patientReadDtos = patients.Select(PatientReadDto.MapFromPatient).ToList().AsReadOnly();
        return new CustomResult(true, HttpStatusCode.OK, patientReadDtos);
    }
}