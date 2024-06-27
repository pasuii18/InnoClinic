using Application.Common.Dtos.Filters;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.PatientValidators;

public class PatientFiltersValidator : AbstractValidator<PatientFilters>
{
    public PatientFiltersValidator()
    {
        RuleFor(query => query)
            .PatientFilters();
    }
}