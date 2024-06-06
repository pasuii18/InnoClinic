using Application.Common.Dtos.Filters;
using Domain.Common.Enums;
using FluentValidation;

namespace Application.Common.Validation.ValidationRules;

public static class DoctorValidationRules
{
    public static IRuleBuilder<T, int> CareerStartYear<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
            .InclusiveBetween(1950, DateTime.Now.Year).WithMessage($"The career start year must be between 1950 and {DateTime.Now.Year}.");
    }
    public static IRuleBuilder<T, DoctorStatus> Status<T>(this IRuleBuilder<T, DoctorStatus> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("The status is required.")
            .IsInEnum().WithMessage("The status must be a valid status.");
    }
    public static IRuleBuilder<T, DoctorFilters> DoctorFilters<T>(this IRuleBuilder<T, DoctorFilters> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Doctor filters cannot be null.")
            .ChildRules(filters =>
            {
                filters.RuleFor(f => f.OrderBy)
                    .OrderBy();
                filters.RuleFor(f => f.OrderType)
                    .OrderType();
                filters.RuleFor(f => f.FullName)
                    .FullName();
                filters.RuleFor(f => f.Status)
                    .Status();
            });
    }
}