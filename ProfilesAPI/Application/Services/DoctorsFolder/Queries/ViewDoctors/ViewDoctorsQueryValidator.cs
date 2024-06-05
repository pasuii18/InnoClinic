using Application.Common.ValidationRules;
using FluentValidation;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctors;

public class ViewDoctorsQueryValidator : AbstractValidator<ViewDoctorsQuery>
{
    public ViewDoctorsQueryValidator()
    {
        RuleFor(query => query.PageSettings)
            .PageSettings();
        RuleFor(query => query.DoctorFilters)
            .DoctorFilters();
    }
}