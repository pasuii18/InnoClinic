using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.EditPatient;

public class EditPatientCommandHandler : IRequestHandler<EditPatientCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(EditPatientCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}