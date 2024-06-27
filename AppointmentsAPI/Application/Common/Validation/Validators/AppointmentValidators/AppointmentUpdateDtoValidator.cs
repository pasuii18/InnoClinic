using Application.Common.Dtos.AppointmentsDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class AppointmentUpdateDtoValidator : AbstractValidator<AppointmentUpdateDto>
{
    public AppointmentUpdateDtoValidator()
    {
        RuleFor(rule => rule.Date)
            .IsDateOnly();
        RuleFor(rule => rule.StartTime)
            .IsTimeOnly();
        RuleFor(rule => rule.EndTime)
            .IsTimeOnly();
        RuleFor(rule => rule.ServiceType)
            .IsInEnum();
        RuleFor(rule => rule.IdDoctor)
            .IsGuid();
    }
}