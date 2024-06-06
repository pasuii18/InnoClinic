using Application.Common.Dtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class PageSettingsValidator : AbstractValidator<PageSettings>
{
    public PageSettingsValidator()
    {
        RuleFor(query => query)
            .PageSettings();
    }
}