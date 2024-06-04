using System.Net;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.CreateDoctor;

public class CreateDoctorCommandHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<CreateDoctorCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = CreateDoctorCommand.MapInDoctor(request);
        await _doctorsRepo.CreateDoctor(doctor, cancellationToken);
        
        return new CustomResult(true, Messages.DoctorCreated, HttpStatusCode.OK, doctor.IdDoctor);   
    }
}