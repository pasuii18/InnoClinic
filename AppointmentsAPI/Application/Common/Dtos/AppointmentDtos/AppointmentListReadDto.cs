namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentListReadDto(Guid IdAppointment, TimeOnly Time,
    string DoctorFullName, string PatientFullName, string PatientPhoneNumber, string ServiceName);