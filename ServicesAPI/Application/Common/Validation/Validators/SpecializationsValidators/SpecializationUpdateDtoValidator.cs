using Application.Common.Dtos.SpecializationDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators.SpecializationsValidators;

public class SpecializationUpdateDtoValidator : AbstractValidator<SpecializationUpdateDto>
{
    public SpecializationUpdateDtoValidator()
    {
        RuleFor(dto => dto.IdSpecialization)
            .IsGuid();
        RuleFor(dto => dto.SpecializationName)
            .SpecializationName();
    }
}