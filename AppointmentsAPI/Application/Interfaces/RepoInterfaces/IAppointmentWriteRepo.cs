using Domain.Entities;

namespace Application.Interfaces.RepoInterfaces;

public interface IAppointmentWriteRepo
{
    public Task CreateAppointment(Appointment appointment, CancellationToken cancellationToken);
    public Task UpdateAppointmentAndSlot(Appointment oldAppointment, Appointment newAppointment,
        CancellationToken cancellationToken);
    public Task UpdateAppointment(Appointment appointment, CancellationToken cancellationToken);

    public Task UpdateAppointmentField<T, T2>(T fieldValue, string fieldName,
        T2 conditionFieldValue, string conditionFieldName, CancellationToken cancellationToken);
    public Task DeleteAppointment(Appointment appointment, CancellationToken cancellationToken);
}