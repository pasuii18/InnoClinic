namespace Application.Common.Dtos;

public record SlotReadDto(DateOnly Date, TimeOnly StartTime, TimeOnly EndTime);