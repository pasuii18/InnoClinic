using Application.Common.Dtos.AppointmentsDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class UpdateAppointmentDtoValidator : AbstractValidator<UpdateAppointmentDto>
{
    public UpdateAppointmentDtoValidator()
    {
        RuleFor(rule => rule.Date)
            .IsDateOnly();
        RuleFor(rule => rule.StartTime)
            .IsTimeOnly();
        RuleFor(rule => rule.EndTime)
            .IsTimeOnly();
        RuleFor(rule => rule.IdDoctor)
            .IsGuid();
    }
}