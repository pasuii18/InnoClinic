namespace Application.Common.Dtos.AppointmentsDtos;

public record GetAppointmentsDto(Guid IdAppointment, TimeOnly StartTime, TimeOnly EndTime,
    string DoctorFullName, string PatientFullName, string PatientPhoneNumber, string ServiceName);