using Domain.Events;
using Domain.Events.DoctorEvents;
using Domain.Events.ServiceEvents;

namespace Application.Interfaces;

public interface IProcessesService
{
    public Task ProcessServiceUpdate(ServiceUpdatedEvent serviceUpdatedEvent,
        CancellationToken cancellationToken);
    public Task ProcessDoctorUpdate(DoctorUpdatedEvent doctorUpdateEvent, 
        CancellationToken cancellationToken);
    public Task ProcessPatientUpdate(PatientUpdatedEvent patientUpdateEvent,
        CancellationToken cancellationToken);
}