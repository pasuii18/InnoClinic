using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.RepoInterfaces;

public interface IAppointmentRepo
{
    public Task<IReadOnlyCollection<Appointment>> GetAppointments(PageSettings pageSettings,
        AppointmentsFilter filters, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Appointment>> GetAppointmentsHistory(PageSettings pageSettings,
        AppointmentsFilter filters, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Appointment>> GetAppointmentsSchedule(PageSettings pageSettings,
        AppointmentsFilter filters, CancellationToken cancellationToken);
    
    public Task<Appointment?> GetAppointmentsById(Guid idAppointment,
        CancellationToken cancellationToken);
    
    public Task CreateAppointment(Appointment appointment, CancellationToken cancellationToken);
    public Task UpdateAppointment(Appointment appointment, CancellationToken cancellationToken);
    public Task UpdateAppointmentStatus(Appointment appointment, CancellationToken cancellationToken);
    public Task DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken);
}