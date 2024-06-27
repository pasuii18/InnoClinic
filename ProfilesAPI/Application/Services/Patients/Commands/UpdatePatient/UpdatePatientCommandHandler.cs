using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.PatientsFolder.Commands.UpdatePatient;

public class UpdatePatientCommandHandler(IPatientsRepo _patientsRepo) : IRequestHandler<UpdatePatientCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientsRepo.GetPatientById(request.IdPatient, cancellationToken);
        if(patient == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.PatientNotFound); 
        
        request.MapInPatient(patient);
        await _patientsRepo.UpdatePatient(patient, cancellationToken);
        
        return new CustomResult(true, HttpStatusCode.OK);    
    }
}