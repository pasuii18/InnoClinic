using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.CreatePatientByAdmin;

public class CreatePatientByAdminCommandHandler : IRequestHandler<CreatePatientByAdminCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(CreatePatientByAdminCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}