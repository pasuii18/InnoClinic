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
        CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Appointment>> GetAppointmentsSchedule(Guid idDoctor, PageSettings pageSettings,
        AppointmentsScheduleFilter filters, CancellationToken cancellationToken);
    
    public Task<Appointment?> GetAppointmentById(Guid idAppointment, CancellationToken cancellationToken);
    public Task<Appointment?> GetAppointmentByFieldName<T>(T value, string fieldName, CancellationToken cancellationToken);
    
    public Task CreateAppointment(Appointment appointment, CancellationToken cancellationToken);
    public Task UpdateAppointment(Appointment appointment, CancellationToken cancellationToken);

    public Task UpdateAppointmentField<T, T2>(T fieldValue, string fieldName,
        T2 conditionFieldValue, string conditionFieldName, CancellationToken cancellationToken);
    public Task DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken);
}