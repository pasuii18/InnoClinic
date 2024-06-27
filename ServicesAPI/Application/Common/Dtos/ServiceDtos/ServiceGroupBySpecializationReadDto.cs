namespace Application.Common.Dtos.ServiceDtos;

public record ServiceGroupBySpecializationReadDto(string SpecializationName, 
    IReadOnlyCollection<ServiceReadDto> Services);