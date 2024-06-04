using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.ReceptionistsFolder.Commands.CreateReceptionist;

public class CreateReceptionistCommandValidator : AbstractValidator<CreateReceptionistCommand>
{
    public CreateReceptionistCommandValidator()
    {
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.Email)
            .EmailAddress();
        RuleFor(command => command.IdOffice)
            .IdOffice();
        RuleFor(command => command.IdPhoto)
            .IdPhoto();
    }
}