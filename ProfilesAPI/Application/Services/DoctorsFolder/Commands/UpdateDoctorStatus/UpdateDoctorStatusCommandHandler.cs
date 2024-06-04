using System.Net;
using Application.Common;
using Application.Common.Dtos.DoctorDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.EditDoctorStatus;

public class UpdateDoctorStatusCommandHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<UpdateDoctorStatusCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(UpdateDoctorStatusCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorsRepo.GetDoctorById(request.IdDoctor, cancellationToken);
        if(doctor == null) return new CustomResult(false, Messages.DoctorNotFound, HttpStatusCode.NotFound);

        doctor.Status = request.Status;
        await _doctorsRepo.UpdateDoctor(doctor, cancellationToken);
        
        return new CustomResult(true, Messages.DoctorStatusUpdated, HttpStatusCode.OK);
    }
}