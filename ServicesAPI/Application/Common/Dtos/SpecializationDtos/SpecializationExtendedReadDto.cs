using Application.Common.Dtos.ServiceDtos;

namespace Application.Common.Dtos.SpecializationDtos;

public record SpecializationExtendedReadDto(Guid IdSpecialization, string SpecializationName, bool IsActive,
    IReadOnlyCollection<ServiceReadDto> Services);