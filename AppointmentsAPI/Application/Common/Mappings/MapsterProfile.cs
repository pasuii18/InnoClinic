using Application.Common.Dtos.ResultDtos;
using Domain.Entities;
using Mapster;

namespace Application.Common.Mappings;

public class MapsterProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
            config.NewConfig<Result, ResultReadDto>()
                .Map(dest => dest.DoctorFullName, src => src.Appointment.DoctorFullName)
                .Map(dest => dest.SpecializationName, src => src.Appointment.SpecializationName)
                .Map(dest => dest.PatientFullName, src => src.Appointment.PatientFullName)
                .Map(dest => dest.PatientDateOfBirth, src => src.Appointment.PatientDateOfBirth)
                .Map(dest => dest.ServiceName, src => src.Appointment.ServiceName);
    }
}