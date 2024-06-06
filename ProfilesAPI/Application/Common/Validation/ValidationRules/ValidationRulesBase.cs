using Application.Common.Dtos;
using Domain.Common.Enums;
using FluentValidation;

namespace Application.Common.Validation.ValidationRules;

public static class ValidationRulesBase
{
    public static IRuleBuilder<T, PageSettings> PageSettings<T>(this IRuleBuilder<T, PageSettings> ruleBuilder)
    {
        ruleBuilder
            .NotNull().WithMessage("Page settings cannot be null.");
        
        return ruleBuilder
            .Must(x => x.Page > 0).WithMessage("Page number must be greater than 0.")
            .Must(x => x.PageSize > 0).WithMessage("Items per page must be greater than 0.");
    }
    public static IRuleBuilder<T, string> FirstName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The first name is required.")
            .MaximumLength(20).WithMessage("The first name must not exceed 20 characters.")
            .Matches(@"^[a-zA-Z'-]+$").WithMessage("The first name can only contain letters, apostrophes, and hyphens.");
    }
    public static IRuleBuilder<T, string> LastName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The last name is required.")
            .MaximumLength(20).WithMessage("The last name must not exceed 20 characters.")
            .Matches(@"^[a-zA-Z'-]+$").WithMessage("The last name can only contain letters, apostrophes, and hyphens.");
    }
    public static IRuleBuilder<T, string> MiddleName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .MaximumLength(20).WithMessage("The middle name must not exceed 20 characters.")
            .Matches(@"^[a-zA-Z'-]+$").WithMessage("The middle name can only contain letters, apostrophes, and hyphens.");
    }
    public static IRuleBuilder<T, DateTime> DateOfBirth<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The date of birth is required.")
            .LessThan(DateTime.Now).WithMessage("The date of birth must be in the past.");
    }
    public static IRuleBuilder<T, OrderBy> OrderBy<T>(this IRuleBuilder<T, OrderBy> ruleBuilder)
    {
        return ruleBuilder
            .IsInEnum().WithMessage("The order by field must be a valid.");
    }
    public static IRuleBuilder<T, OrderType> OrderType<T>(this IRuleBuilder<T, OrderType> ruleBuilder)
    {
        return ruleBuilder
            .IsInEnum().WithMessage("The order type field must be a valid.");
    }
    public static IRuleBuilder<T, string> FullName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(@"^[a-zA-Z '-]*$").WithMessage("The full name can only contain letters, spaces, apostrophes and hyphens");
    }
    public static IRuleBuilder<T, Guid> GuidRule<T>(this IRuleBuilder<T, Guid> ruleBuilder)
    {
        return ruleBuilder
            .NotEqual(Guid.Empty);
    }
    public static IRuleBuilder<T, string> IdOffice<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The office id is required and cannot be an empty.");
    }
}