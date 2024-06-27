using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.DoctorsFolder.Commands.CreateDoctor;

public class CreateDoctorCommandHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<CreateDoctorCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = CreateDoctorCommand.MapInDoctor(request);
        await _doctorsRepo.CreateDoctor(doctor, cancellationToken);
        
        return new CustomResult(true, HttpStatusCode.OK, doctor.IdDoctor);   
    }
}