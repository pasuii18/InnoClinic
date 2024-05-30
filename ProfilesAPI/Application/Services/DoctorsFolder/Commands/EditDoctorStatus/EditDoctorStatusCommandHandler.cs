using Application.Interfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.EditDoctorStatus;

public class EditDoctorStatusCommandHandler : IRequestHandler<EditDoctorStatusCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(EditDoctorStatusCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}