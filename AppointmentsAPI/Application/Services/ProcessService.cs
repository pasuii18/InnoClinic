using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Events;
using Domain.Events.DoctorEvents;
using Domain.Events.ServiceEvents;

namespace Application.Services;

public class ProcessService(IAppointmentRepo _appointmentRepo) : IProcessesService
{
    public async Task ProcessDoctorUpdate(DoctorUpdatedEvent doctorUpdateEvent, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepo
            .GetAppointmentByFieldName(doctorUpdateEvent.IdDoctor, nameof(doctorUpdateEvent.IdDoctor),
                cancellationToken);
        
        if (appointment != null)
        {
            await _appointmentRepo.UpdateAppointmentField(
                doctorUpdateEvent.DoctorFullName, nameof(doctorUpdateEvent.DoctorFullName), 
                doctorUpdateEvent.IdDoctor, nameof(doctorUpdateEvent.IdDoctor), 
                cancellationToken);
        }
    }
    public async Task ProcessPatientUpdate(PatientUpdatedEvent patientUpdateEvent, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepo
            .GetAppointmentByFieldName(patientUpdateEvent.IdPatient, nameof(patientUpdateEvent.IdPatient),
                cancellationToken);
        
        if (appointment != null)
        {
            appointment.PatientFullName = patientUpdateEvent.PatientFullName;
            appointment.PatientPhoneNumber = patientUpdateEvent.PatientPhoneNumber;
            appointment.PatientDateOfBirth = patientUpdateEvent.PatientDateOfBirth;
            await _appointmentRepo.UpdateAppointment(appointment, cancellationToken);
        }
    }
    public async Task ProcessServiceUpdate(ServiceUpdatedEvent serviceUpdatedEvent, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepo
            .GetAppointmentByFieldName(serviceUpdatedEvent.IdService, nameof(serviceUpdatedEvent.IdService),
                cancellationToken);
        
        if (appointment != null)
        {
            appointment.ServiceName = serviceUpdatedEvent.ServiceName;
            appointment.SpecializationName = serviceUpdatedEvent.SpecializationName;
            await _appointmentRepo.UpdateAppointment(appointment, cancellationToken);
        }
    }
}