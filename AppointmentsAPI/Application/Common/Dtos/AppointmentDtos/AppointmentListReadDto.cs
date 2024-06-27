namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentListReadDto(Guid IdAppointment, TimeOnly StartTime, TimeOnly EndTime,
    string DoctorFullName, string PatientFullName, string PatientPhoneNumber, string ServiceName);