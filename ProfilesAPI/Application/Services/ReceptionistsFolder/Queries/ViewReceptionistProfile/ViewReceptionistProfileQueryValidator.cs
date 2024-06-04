using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionistProfile;

public class ViewReceptionistProfileQueryValidator : AbstractValidator<ViewReceptionistProfileQuery>
{
    public ViewReceptionistProfileQueryValidator()
    {
        RuleFor(query => query.IdReceptionist)
            .IdReceptionist();
    }
}