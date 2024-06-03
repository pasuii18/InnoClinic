using System.Net;
using Application.Common;
using Application.Common.Dtos.PatientDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Queries.ViewPatientProfile;

public class ViewPatientProfileQueryHandler(IPatientsRepo _patientsRepo) : IRequestHandler<ViewPatientProfileQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(ViewPatientProfileQuery request, CancellationToken cancellationToken)
    {
        var patient = await _patientsRepo.GetPatientById(
            request.IdPatient, cancellationToken);
        
        if (patient == null) return new CustomResult(false, Messages.PatientNotFound, (int)HttpStatusCode.NotFound);

        var patientReadDto = PatientReadDto.MapFromPatient(patient);
        return new CustomResult(true, Messages.Success, (int)HttpStatusCode.OK, patientReadDto);
    }
}