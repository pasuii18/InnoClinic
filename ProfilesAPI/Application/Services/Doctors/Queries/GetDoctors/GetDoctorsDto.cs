using Domain.Entities;

namespace Application.Common.Dtos.DoctorDtos;

public record GetDoctorsDto(IReadOnlyCollection<GetDoctorProfileDto> Doctors)
{
    public static GetDoctorsDto MapFromDoctors(IReadOnlyCollection<Doctor> doctors)
    {
        return new GetDoctorsDto(doctors.Select(GetDoctorProfileDto.MapFromDoctor).ToList().AsReadOnly());
    }
}