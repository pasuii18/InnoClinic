using Application.Common.Dtos.AppointmentsDtos;
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

            config.NewConfig<AppointmentCreateDto, Appointment>()
                .Map(dest => dest.IdAppointment, src => Guid.NewGuid())
                .Map(dest => dest.IsApproved, src => false);

            config.NewConfig<Slot, Appointment>()
                .Map(dest => dest.Date, src => src.Date)
                .Map(dest => dest.StartTime, src => src.StartTime)
                .Map(dest => dest.EndTime, src => src.EndTime)
                .IgnoreNonMapped(true);
    }
}