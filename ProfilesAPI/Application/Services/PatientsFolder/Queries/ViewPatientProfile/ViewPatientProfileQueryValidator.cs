using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.PatientsFolder.Queries.ViewPatientProfile;

public class ViewPatientProfileQueryValidator : AbstractValidator<ViewPatientProfileQuery>
{
    public ViewPatientProfileQueryValidator()
    {
        RuleFor(query => query.IdPatient)
            .IdPatient();
    }
}