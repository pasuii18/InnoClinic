using Application.Common.Dtos.Filters;
using FluentValidation;

namespace Application.Common.ValidationRules;

public static class ReceptionistValidationRules
{
    public static IRuleBuilder<T, Guid> IdReceptionist<T>(this IRuleBuilder<T, Guid> ruleBuilder)
    {
        return ruleBuilder
            .NotEqual(Guid.Empty).WithMessage("The receptionist ID is required.");
    }
    public static IRuleBuilder<T, ReceptionistFilters> ReceptionistFilters<T>(this IRuleBuilder<T, ReceptionistFilters> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Receptionist filters cannot be null.")
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