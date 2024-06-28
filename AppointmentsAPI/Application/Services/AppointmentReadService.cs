using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Mapster;

namespace Application.Services;

public class AppointmentReadService(IAppointmentReadRepo _appointmentReadRepo) : IAppointmentReadService
{
    public async Task<ICustomResult> GetAppointments(PageSettings pageSettings,
        AppointmentsFilter filter, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentReadRepo.GetAppointments(pageSettings, filter, cancellationToken);
        var appointmentsDto = appointments.Adapt<IReadOnlyCollection<GetAppointmentsDto>>();
        return new CustomResult(true, HttpStatusCode.OK, appointmentsDto);
    }
    public async Task<ICustomResult> GetAppointmentsHistory(PageSettings pageSettings,
        CancellationToken cancellationToken)
    {
        var appointments = await _appointmentReadRepo.GetAppointmentsHistory(pageSettings, cancellationToken);
        var appointmentsDto = appointments.Adapt<IReadOnlyCollection<GetHistoryAppointmentDto>>();
        return new CustomResult(true, HttpStatusCode.OK, appointmentsDto);
    }
    public async Task<ICustomResult> GetAppointmentsSchedule(Guid idDoctor, PageSettings pageSettings,
        AppointmentsScheduleFilter filter, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentReadRepo.GetAppointmentsSchedule(idDoctor, pageSettings, filter, cancellationToken);
        var appointmentsDto = appointments.Adapt<IReadOnlyCollection<GetScheduleAppointmentDto>>();
        return new CustomResult(true, HttpStatusCode.OK, appointmentsDto);
    }
}