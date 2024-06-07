namespace Application.Common.Dtos.ServiceDtos;

public record ServiceCreateDto(string ServiceName, decimal Price, bool IsActive, Guid IdServiceCategory);