namespace Application.Common.Dtos.AppointmentsDtos;

public record GetScheduleAppointmentDto(Guid IdAppointment, DateOnly Date, TimeOnly StartTime, TimeOnly EndTime,
    string PatientFullName, Guid IdPatient, string ServiceName, bool IsApproved);