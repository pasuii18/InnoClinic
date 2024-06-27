using Domain.Common;

namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentUpdateDto(DateOnly Date, TimeOnly StartTime, TimeOnly EndTime, 
    ServiceType ServiceType, Guid IdDoctor);