using Application.Common.Dtos.Filters;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class AppointmentsFilterValidator : AbstractValidator<AppointmentsFilter>
{
    public AppointmentsFilterValidator()
    {
        RuleFor(f => f.IsApproved)
            .IsInEnum();
    }
}