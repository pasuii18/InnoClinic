using Application.Common.ValidationRules;
using FluentValidation;

namespace Application.Services.ReceptionistsFolder.Commands.UpdateReceptionist;

public class UpdateReceptionistCommandValidation : AbstractValidator<UpdateReceptionistCommand>
{
    public UpdateReceptionistCommandValidation()
    {
        RuleFor(command => command.IdReceptionist)
            .IdReceptionist();
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.IdOffice)
            .IdOffice();
        RuleFor(command => command.IdPhoto)
            .IdPhoto();
    }
}