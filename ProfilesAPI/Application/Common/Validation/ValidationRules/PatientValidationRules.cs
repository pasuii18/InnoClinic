using Application.Common.Dtos.Filters;
using FluentValidation;

namespace Application.Common.Validation.ValidationRules;

public static class PatientValidationRules
{
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