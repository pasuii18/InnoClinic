namespace Application.Common.Dtos.SpecializationDtos;

public record SpecializationCreateDto(string SpecializationName, bool IsActive,
    IReadOnlyCollection<Guid> IdsService);