namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentHistoryReadDto(Guid IdAppointment, DateOnly Date, TimeOnly StartTime, TimeOnly EndTime,
    string DoctorFullName, string ServiceName);