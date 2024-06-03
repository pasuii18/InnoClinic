using System.Net;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.DeletePatient;

public class DeletePatientCommandHandler(IPatientsRepo _patientsRepo) : IRequestHandler<DeletePatientCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientsRepo.GetPatientById(request.IdPatient, cancellationToken);
        
        if(patient == null) return new CustomResult(false, Messages.PatientNotFound, (int)HttpStatusCode.NotFound); 
        
        await _patientsRepo.DeletePatient(
            request.IdPatient, cancellationToken);
        
        return new CustomResult(true, Messages.PatientDeleted, (int)HttpStatusCode.OK);    
    }
}