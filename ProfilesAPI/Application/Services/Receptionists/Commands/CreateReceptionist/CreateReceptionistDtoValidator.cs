using Application.Common.Dtos.ReceptionistDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.ReceptionistValidators;

public class CreateReceptionistDtoValidator : AbstractValidator<CreateReceptionistDto>
{
    public CreateReceptionistDtoValidator()
    {
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.IdOffice)
            .IdOffice();
    }
}