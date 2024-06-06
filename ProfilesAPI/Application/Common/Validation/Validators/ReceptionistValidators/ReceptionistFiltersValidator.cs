using Application.Common.Dtos.Filters;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.ReceptionistValidators;

public class ReceptionistFiltersValidator : AbstractValidator<ReceptionistFilters>
{
    public ReceptionistFiltersValidator()
    {
        RuleFor(query => query)
            .ReceptionistFilters();
    }
}