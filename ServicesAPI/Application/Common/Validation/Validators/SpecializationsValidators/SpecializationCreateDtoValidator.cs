using Application.Common.Dtos.SpecializationDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators.SpecializationsValidators;

public class SpecializationCreateDtoValidator : AbstractValidator<SpecializationCreateDto>
{
    public SpecializationCreateDtoValidator()
    {
        RuleFor(dto => dto.SpecializationName)
            .SpecializationName();
        RuleForEach(dto => dto.IdsService)
            .IsGuid();
    }
}