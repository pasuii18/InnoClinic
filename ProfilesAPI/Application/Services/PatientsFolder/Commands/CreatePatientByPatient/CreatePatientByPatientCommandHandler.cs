using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.CreatePatientByPatient;

public class CreatePatientByPatientCommandHandler : IRequestHandler<CreatePatientByPatientCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(CreatePatientByPatientCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}