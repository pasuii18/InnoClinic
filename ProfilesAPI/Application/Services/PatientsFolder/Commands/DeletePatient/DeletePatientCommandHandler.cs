using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.PatientsFolder.Commands.DeletePatient;

public class DeletePatientCommandHandler(IPatientsRepo _patientsRepo) : IRequestHandler<DeletePatientCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientsRepo.GetPatientById(request.IdPatient, cancellationToken);
        
        if(patient == null) return new CustomResult(false, HttpStatusCode.NotFound); 
        
        await _patientsRepo.DeletePatient(
            request.IdPatient, cancellationToken);
        
        return new CustomResult(true, HttpStatusCode.OK);    
    }
}