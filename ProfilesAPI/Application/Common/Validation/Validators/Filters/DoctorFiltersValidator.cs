using Application.Common.Dtos.Filters;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.DoctorValidators;

public class DoctorFiltersValidator : AbstractValidator<DoctorFilters>
{
    public DoctorFiltersValidator()
    {
        RuleFor(query => query)
            .DoctorFilters();
    }
}