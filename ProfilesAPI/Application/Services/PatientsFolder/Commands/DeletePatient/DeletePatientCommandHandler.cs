using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.DeletePatient;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}