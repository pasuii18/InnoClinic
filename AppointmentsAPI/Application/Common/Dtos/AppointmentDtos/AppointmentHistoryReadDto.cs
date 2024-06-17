namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentHistoryReadDto(Guid IdAppointment, DateOnly Date, TimeOnly Time,
    string DoctorFullName, string ServiceName);