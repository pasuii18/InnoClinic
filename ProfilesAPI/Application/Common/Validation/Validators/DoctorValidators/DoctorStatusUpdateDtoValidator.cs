using Application.Common.Dtos.DoctorDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.DoctorValidators;

public class DoctorStatusUpdateDtoValidator : AbstractValidator<DoctorStatusUpdateDto>
{
    public DoctorStatusUpdateDtoValidator()
    {
        RuleFor(command => command.IdDoctor)
            .GuidRule();
        RuleFor(command => command.Status)
            .Status();
    }
}