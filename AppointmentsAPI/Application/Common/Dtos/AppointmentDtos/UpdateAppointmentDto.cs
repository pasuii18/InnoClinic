using Domain.Common;

namespace Application.Common.Dtos.AppointmentsDtos;

public record UpdateAppointmentDto(DateOnly Date, TimeOnly StartTime, TimeOnly EndTime, int SlotSize, Guid IdDoctor);