using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.PatientsFolder.Queries.ViewPatients;

public class ViewPatientsQueryValidator : AbstractValidator<ViewPatientsQuery>
{
    public ViewPatientsQueryValidator()
    {
        RuleFor(query => query.PageSettings)
            .PageSettings();
        RuleFor(query => query.PatientFilters)
            .PatientFilters();
    }
}