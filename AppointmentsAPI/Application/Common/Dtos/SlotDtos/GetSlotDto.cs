namespace Application.Common.Dtos;

public record GetSlotDto(DateOnly Date, TimeOnly StartTime, TimeOnly EndTime);