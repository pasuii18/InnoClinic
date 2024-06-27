using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.DoctorsFolder.Commands.UpdateDoctorStatus;

public class UpdateDoctorStatusCommandHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<UpdateDoctorStatusCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(UpdateDoctorStatusCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorsRepo.GetDoctorById(request.IdDoctor, cancellationToken);
        if(doctor == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.DoctorNotFound);

        doctor.Status = request.Status;
        await _doctorsRepo.UpdateDoctor(doctor, cancellationToken);
        
        return new CustomResult(true, HttpStatusCode.OK);
    }
}