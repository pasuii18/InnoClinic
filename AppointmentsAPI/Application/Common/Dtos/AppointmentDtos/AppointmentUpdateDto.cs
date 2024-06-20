namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentUpdateDto(DateOnly Date, TimeOnly Time, Guid IdDoctor);