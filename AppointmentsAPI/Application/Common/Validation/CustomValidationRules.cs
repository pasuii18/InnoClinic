using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Common;
using FluentValidation;

namespace Application.Common.Validation;

public static class CustomValidationRules
{
    public static IRuleBuilder<T, PageSettings> PageSettings<T>(
        this IRuleBuilder<T, PageSettings> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Page settings cannot be null.")
            .Must(x => x.Page > 0).WithMessage("Page number must be greater than 0.")
            .Must(x => x.PageSize > 0).WithMessage("Items per page must be greater than 0.");
    }
    public static IRuleBuilder<T, Guid> IsGuid<T>(
        this IRuleBuilder<T, Guid> ruleBuilder)
    {
        return ruleBuilder
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot by empty guid!");
    }
    public static IRuleBuilder<T, string> IsDoctorResult<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The {PropertyName} is required.")
            .MaximumLength(300).WithMessage("The {PropertyName} must not exceed 300 characters.")
            .Matches(@"^[a-zA-Z0-9.,?!\- ]+$").WithMessage("The {PropertyName} can only contain letters, numbers and symbols .,?!- ");
    }
    public static IRuleBuilder<T, DateOnly> IsDateOnly<T>(
        this IRuleBuilder<T, DateOnly> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The date is required.")
            .Must((obj, date) => BeValidDate(date))
            .WithMessage("The date '{PropertyValue}' must be in the format dd.MM.yyyy");

        bool BeValidDate(DateOnly date)
        {
            var dateString = date.ToString("dd.MM.yyyy");
            return DateOnly.TryParseExact(dateString, "dd.MM.yyyy", null, 
                System.Globalization.DateTimeStyles.None, out _);
        }
    }
    public static IRuleBuilder<T, TimeOnly> IsTimeOnly<T>(
        this IRuleBuilder<T, TimeOnly> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("The time is required.")
            .Must(BeValidTime).WithMessage("The time must be in the format HH:mm");

        bool BeValidTime(TimeOnly time)
        {
            var timeString = time.ToString("HH:mm");
            return TimeOnly.TryParseExact(timeString, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _);
        }
    }
}