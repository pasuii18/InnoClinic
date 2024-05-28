using FluentValidation;

namespace Application.Common.Validation.Validators;

public class PageSettingsValidator : AbstractValidator<PageSettings>
{
    public PageSettingsValidator()
    {
        RuleFor(pageSettings => pageSettings)
            .PageSettings();
    }
}