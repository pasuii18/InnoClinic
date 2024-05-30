using Application.Interfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, ICustomResult>
{
    public Task<ICustomResult> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}