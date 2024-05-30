using Application.Interfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.EditDoctor;

public class EditDoctorCommandHandler : IRequestHandler<EditDoctorCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(EditDoctorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}