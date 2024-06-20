using Application.Common.Dtos.Filters;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class AppointmentsScheduleFilterValidator  : AbstractValidator<AppointmentsScheduleFilter>
{
    public AppointmentsScheduleFilterValidator()
    {
        RuleFor(rule => rule.Date)
            .IsDateOnly();
    }
}