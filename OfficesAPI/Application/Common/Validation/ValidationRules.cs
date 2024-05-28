using FluentValidation;

namespace Application.Common.Validation;

public static class ValidationRules
{
    public static IRuleBuilderOptions<T, string> Address<T>(this IRuleBuilder<T, string> ruleBuilder)
    {        
        return ruleBuilder
            .NotEmpty().WithMessage("The office address is required.")
            .MaximumLength(100).WithMessage("The office address must not exceed 100 characters.")
            .Matches(@"^[a-zA-Z]{2,20},\s*[a-zA-Z0-9]{2,20},\s*[a-zA-Z0-9]{1,5},\s*[a-zA-Z0-9]{1,5}$")
            .WithMessage("The address is invalid. It must be in the format: 'Street, City, House, Office'.");
    }
    
    public static IRuleBuilderOptions<T, string> RegistryPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {        
        return ruleBuilder
            .NotEmpty().WithMessage("The registry phone number is required.")
            .MaximumLength(20).WithMessage("The registry phone number must not exceed 20 characters.")
            .Matches(@"^\+\d{7,15}$").WithMessage("The registry phone number must contain between 7 and 15 digits after the plus sign.");
    }
    
    public static IRuleBuilder<T, PageSettings> PageSettings<T>(this IRuleBuilder<T, PageSettings> ruleBuilder)
    {
        ruleBuilder
            .NotNull().WithMessage("Page settings cannot be null.");
        
        return ruleBuilder
            .Must(x => x.Page > 0).WithMessage("Page number must be greater than 0.")
            .Must(x => x.PageSize > 0).WithMessage("Items per page must be greater than 0.");
    }
}