using Application.Common.Dtos.Filters;
using FluentValidation;

namespace Application.Common.Validation.ValidationRules;

public static class PatientValidationRules
{
    public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {        
        return ruleBuilder
            .NotEmpty().WithMessage("The registry phone number is required.")
            .MaximumLength(20).WithMessage("The registry phone number must not exceed 20 characters.")
            .Matches(@"^\+\d{7,15}$").WithMessage("The registry phone number must contain between 7 and 15 digits after the plus sign.");
    }
    public static IRuleBuilder<T, PatientFilters> PatientFilters<T>(this IRuleBuilder<T, PatientFilters> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Patient filters cannot be null.")
            .ChildRules(filters =>
            {
                filters.RuleFor(f => f.OrderBy)
                    .OrderBy();
                filters.RuleFor(f => f.OrderType)
                    .OrderType();
                filters.RuleFor(f => f.FullName)
                    .FullName();
            });
    }
}