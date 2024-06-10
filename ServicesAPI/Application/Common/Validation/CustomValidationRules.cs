using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Validation.Validators;
using FluentValidation;

namespace Application.Common.Validation;

public static class CustomValidationRules
{
    public static IRuleBuilder<T, PageSettings> PageSettings<T>(this IRuleBuilder<T, PageSettings> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Page settings cannot be null.")
            .Must(x => x.Page > 0).WithMessage("Page number must be greater than 0.")
            .Must(x => x.PageSize > 0).WithMessage("Items per page must be greater than 0.");
    }
    public static IRuleBuilder<T, Guid> IsGuid<T>(this IRuleBuilder<T, Guid> ruleBuilder)
    {
        return ruleBuilder
            .NotEqual(Guid.Empty).WithMessage("Value cannot by empty guid!");
    }
    public static IRuleBuilder<T, string> SpecializationName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The specialization name is required.")
            .MaximumLength(50).WithMessage("The specialization name must not exceed 50 characters.")
            .Matches(@"^[a-zA-Z]+$").WithMessage("The specialization name can only contain letters.");
    }
    public static IRuleBuilder<T, string> ServiceName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The service name is required.")
            .MaximumLength(50).WithMessage("The service name must not exceed 50 characters.")
            .Matches(@"^[a-zA-Z]+$").WithMessage("The service name can only contain letters.");
    }
    public static IRuleBuilder<T, decimal> Price<T>(this IRuleBuilder<T, decimal> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.")
            .LessThan(9999).WithMessage("Price must be less than 9999.");
    }
    public static IRuleBuilder<T, ServicesFilter> ServicesFilter<T>(this IRuleBuilder<T, ServicesFilter> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Services filter cannot be null.")
            .Must(x => x.IdServiceCategory != Guid.Empty).WithMessage("Value cannot by empty guid!");
    }
}