namespace Application.Common.Dtos.ServiceDtos;

public record ServiceUpdateDto(Guid IdService, string ServiceName, 
    decimal Price, bool IsActive, Guid IdServiceCategory);