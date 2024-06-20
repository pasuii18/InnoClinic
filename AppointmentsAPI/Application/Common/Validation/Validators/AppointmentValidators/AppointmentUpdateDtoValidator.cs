using Application.Common.Dtos.AppointmentsDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class AppointmentUpdateDtoValidator : AbstractValidator<AppointmentUpdateDto>
{
    public AppointmentUpdateDtoValidator()
    {
        RuleFor(rule => rule.Date)
            .IsDateOnly();
        RuleFor(rule => rule.Time)
            .IsTimeOnly();
        RuleFor(rule => rule.IdDoctor)
            .IsGuid();
    }
}