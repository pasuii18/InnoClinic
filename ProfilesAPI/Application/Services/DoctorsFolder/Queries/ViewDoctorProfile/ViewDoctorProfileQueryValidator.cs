using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctorProfile;

public class ViewDoctorProfileQueryValidator : AbstractValidator<ViewDoctorProfileQuery>
{
    public ViewDoctorProfileQueryValidator()
    {
        RuleFor(query => query.IdDoctor)
            .IdDoctor();
    }
}