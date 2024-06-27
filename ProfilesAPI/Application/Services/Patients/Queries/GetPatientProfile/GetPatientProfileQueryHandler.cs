using Application.Common;
using Application.Common.Dtos.PatientDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.PatientsFolder.Queries.ViewPatientProfile;

public class GetPatientProfileQueryHandler(IPatientsRepo _patientsRepo) : IRequestHandler<GetPatientProfileQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(GetPatientProfileQuery request, CancellationToken cancellationToken)
    {
        var patient = await _patientsRepo.GetPatientById(
            request.IdPatient, cancellationToken);
        
        if (patient == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.PatientNotFound);

        var patientDto = GetPatientProfileDto.MapFromPatient(patient);
        return new CustomResult(true, HttpStatusCode.OK, patientDto);
    }
}