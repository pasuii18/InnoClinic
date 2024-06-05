using Application.Common;
using Application.Common.Dtos.DoctorDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctorProfile;

public class ViewDoctorProfileQueryHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<ViewDoctorProfileQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(ViewDoctorProfileQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorsRepo.GetDoctorById(request.IdDoctor, cancellationToken);
        if(doctor == null) return new CustomResult(false, Messages.DoctorNotFound, HttpStatusCode.NotFound);

        var doctorDto = DoctorReadDto.MapFromDoctor(doctor);
        return new CustomResult(true, Messages.Success, HttpStatusCode.OK, doctorDto);
    }
}