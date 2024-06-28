using Application.Common.Dtos.AppointmentsDtos;

namespace Application.Interfaces;

public interface IAppointmentWriteService
{
    // US-6, US-64
    public Task<ICustomResult> CreateAppointment(CreateAppointmentDto createAppointmentDto, CancellationToken cancellationToken);
    // US-66, US-67 Only appointments that aren’t approved can be rescheduled
    public Task<ICustomResult> UpdateAppointment(Guid idAppointment, UpdateAppointmentDto updateAppointmentDto, CancellationToken cancellationToken);
    // US-14
    public Task<ICustomResult> UpdateAppointmentStatus(Guid idAppointment, CancellationToken cancellationToken);
    // US-15
    public Task<ICustomResult> DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken);
}