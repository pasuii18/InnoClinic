using Application.Common.Dtos.AppointmentsDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class AppointmentCreateDtoValidator : AbstractValidator<AppointmentCreateDto>
{
    public AppointmentCreateDtoValidator()
    {
        RuleFor(rule => rule.Date)
            .IsDateOnly();
        RuleFor(rule => rule.Time)
            .IsTimeOnly();
        RuleFor(rule => rule.IdPatient)
            .IsGuid();
        RuleFor(rule => rule.IdDoctor)
            .IsGuid();
        RuleFor(rule => rule.IdService)
            .IsGuid();
    }
}