namespace Application.Common.Dtos.ServiceCategoryDtos;

public record ServiceCategoryReadDto(Guid IdServiceCategory, string ServiceCategoryName, int TimeSlotSize);