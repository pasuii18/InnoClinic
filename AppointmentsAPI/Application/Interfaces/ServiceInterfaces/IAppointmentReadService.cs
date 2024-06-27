using Application.Common.Dtos;
using Application.Common.Dtos.Filters;

namespace Application.Interfaces;

public interface IAppointmentReadService
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
}