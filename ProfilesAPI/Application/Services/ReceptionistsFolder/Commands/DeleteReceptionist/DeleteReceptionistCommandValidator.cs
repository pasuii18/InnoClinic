using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.ReceptionistsFolder.Commands.DeleteReceptionist;

public class DeleteReceptionistCommandValidator : AbstractValidator<DeleteReceptionistCommand>
{
    public DeleteReceptionistCommandValidator()
    {
        RuleFor(command => command.IdReceptionist)
            .IdReceptionist();
    }
}