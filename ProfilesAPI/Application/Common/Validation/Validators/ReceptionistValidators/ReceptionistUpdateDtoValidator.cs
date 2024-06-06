using Application.Common.Dtos.ReceptionistDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.ReceptionistValidators;

public class ReceptionistUpdateDtoValidator : AbstractValidator<ReceptionistUpdateDto>
{
    public ReceptionistUpdateDtoValidator()
    {
        RuleFor(command => command.IdReceptionist)
            .GuidRule();
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.IdOffice)
            .GuidRule();
        RuleFor(command => command.IdPhoto)
            .GuidRule();
    }
}