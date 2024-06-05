using Application.Common;
using Application.Common.Dtos.DoctorDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;
using System.Net;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctors;

public class ViewDoctorsQueryHandler(IDoctorsRepo _doctorsRepo)
    : IRequestHandler<ViewDoctorsQuery, ICustomResult>
{
    public async Task<ICustomResult> Handle(ViewDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _doctorsRepo.GetDoctorsByFiltration(
            request.PageSettings, request.DoctorFilters, cancellationToken);
        
        // + PHOTO AND SPECIALIZATION + OFFICE ADDRESS
        var doctorsDtos = doctors.Select(DoctorReadDto.MapFromDoctor).ToList().AsReadOnly();
        return new CustomResult(true, Messages.Success, HttpStatusCode.OK, doctorsDtos);
    }
}