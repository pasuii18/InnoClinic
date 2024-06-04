using System.Net;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.UpdatePatient;

public class UpdatePatientCommandHandler(IPatientsRepo _patientsRepo) : IRequestHandler<UpdatePatientCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientsRepo.GetPatientById(request.IdPatient, cancellationToken);
        if(patient == null) return new CustomResult(false, Messages.PatientNotFound, HttpStatusCode.NotFound); 
        
        request.MapInPatient(patient);
        await _patientsRepo.UpdatePatient(patient, cancellationToken);
        
        return new CustomResult(true, Messages.PatientUpdated, HttpStatusCode.OK);    
    }
}