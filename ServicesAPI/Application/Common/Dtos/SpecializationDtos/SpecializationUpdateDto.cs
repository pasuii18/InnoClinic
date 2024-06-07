namespace Application.Common.Dtos.SpecializationDtos;

public record SpecializationUpdateDto(Guid IdSpecialization, string SpecializationName, bool IsActive);