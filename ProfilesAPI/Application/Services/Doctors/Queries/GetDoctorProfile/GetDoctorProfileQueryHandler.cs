using Application.Common;
using Application.Common.Dtos.DoctorDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctorProfile;

public class GetDoctorProfileQueryHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<GetDoctorProfileQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(GetDoctorProfileQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorsRepo.GetDoctorById(request.IdDoctor, cancellationToken);
        if(doctor == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.DoctorNotFound);

        var doctorDto = GetDoctorProfileDto.MapFromDoctor(doctor);
        return new CustomResult(true, HttpStatusCode.OK, doctorDto);
    }
}