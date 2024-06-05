using Application.Common.ValidationRules;
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