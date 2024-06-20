using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;

namespace Application.Interfaces;

public interface IAppointmentService
{
    // US-13
    public Task<ICustomResult> GetAppointments(PageSettings pageSettings,
        AppointmentsFilter filter, CancellationToken cancellationToken);
    // US-45, US-46
    public Task<ICustomResult> GetAppointmentsHistory(PageSettings pageSettings,
        CancellationToken cancellationToken);
    // US-10
    public Task<ICustomResult> GetAppointmentsSchedule(Guid idDoctor, PageSettings pageSettings,
        AppointmentsScheduleFilter filter, CancellationToken cancellationToken);
    // US-6, US-64
    public Task<ICustomResult> CreateAppointment(AppointmentCreateDto appointmentCreateDto, CancellationToken cancellationToken);
    // US-66, US-67 Only appointments that aren’t approved can be rescheduled
    public Task<ICustomResult> UpdateAppointment(Guid idAppointment, AppointmentUpdateDto appointmentUpdateDto, CancellationToken cancellationToken);
    // US-14
    public Task<ICustomResult> UpdateAppointmentStatus(Guid idAppointment, CancellationToken cancellationToken);
    // US-15
    public Task<ICustomResult> DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken);
}
// us-65 ??????