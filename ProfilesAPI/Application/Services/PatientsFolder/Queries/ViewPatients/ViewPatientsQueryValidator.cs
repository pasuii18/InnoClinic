using Application.Common.ValidationRules;
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