using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.RepoInterfaces;

public interface IAppointmentReadRepo
{
    public Task<IReadOnlyCollection<Appointment>> GetAppointments(PageSettings pageSettings,
        AppointmentsFilter filters, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Appointment>> GetAppointmentsHistory(PageSettings pageSettings,
        CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Appointment>> GetAppointmentsSchedule(Guid idDoctor, PageSettings pageSettings,
        AppointmentsScheduleFilter filters, CancellationToken cancellationToken);
    
    public Task<Appointment?> GetAppointmentById(Guid idAppointment, CancellationToken cancellationToken);
    public Task<Appointment?> GetAppointmentByFieldName<T>(T value, string fieldName, CancellationToken cancellationToken);
}