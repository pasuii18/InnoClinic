using Application.Common.ValidationRules;
using FluentValidation;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionists;

public class ViewReceptionistsQueryValidator : AbstractValidator<ViewReceptionistsQuery>
{
    public ViewReceptionistsQueryValidator()
    {
        RuleFor(query => query.PageSettings)
            .PageSettings();
        RuleFor(query => query.ReceptionistFilters)
            .ReceptionistFilters();
    }
}