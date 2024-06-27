using Application.Common;
using Application.Common.Dtos.DoctorDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctors;

public class GetDoctorsQueryHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<GetDoctorsQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _doctorsRepo.GetDoctorsByFiltration(
            request.PageSettings, request.DoctorFilters, cancellationToken);
        
        var doctorsDto = GetDoctorsDto.MapFromDoctors(doctors);
        return new CustomResult(true, HttpStatusCode.OK, doctorsDto);
    }
}