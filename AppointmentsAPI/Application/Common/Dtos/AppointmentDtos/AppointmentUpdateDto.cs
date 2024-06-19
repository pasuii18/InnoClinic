namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentUpdateDto(Guid IdAppointment, DateOnly Date, TimeOnly Time, Guid IdDoctor);