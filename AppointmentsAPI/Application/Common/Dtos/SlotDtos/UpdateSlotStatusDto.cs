using Domain.Common;

namespace Application.Common.Dtos.SlotDtos;

public record UpdateSlotStatusDto(DateOnly Date, TimeOnly StartTime, TimeOnly EndTime);