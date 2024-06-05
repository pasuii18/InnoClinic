using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.DoctorsFolder.Commands.UpdateDoctor;

public class UpdateDoctorCommandHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<UpdateDoctorCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorsRepo.GetDoctorById(request.IdDoctor, cancellationToken);
        if(doctor == null) return new CustomResult(false, Messages.DoctorNotFound, HttpStatusCode.NotFound);

        request.MapInDoctor(doctor);
        await _doctorsRepo.UpdateDoctor(doctor, cancellationToken);
        
        return new CustomResult(true, Messages.DoctorUpdated, HttpStatusCode.OK);
    }
}