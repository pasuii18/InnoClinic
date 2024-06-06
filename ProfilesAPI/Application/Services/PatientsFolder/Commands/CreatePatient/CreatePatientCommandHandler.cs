using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.PatientsFolder.Commands.CreatePatient;

public class CreatePatientCommandHandler(IPatientsRepo _patientsRepo) : IRequestHandler<CreatePatientCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = CreatePatientCommand.MapInPatient(request);
        await _patientsRepo.CreatePatient(patient, cancellationToken);
        
        return new CustomResult(true, HttpStatusCode.OK, patient.IdPatient);   
    }
}