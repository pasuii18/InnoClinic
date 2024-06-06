using Application.Common.Dtos.ReceptionistDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.ReceptionistValidators;

public class ReceptionistCreateDtoValidator : AbstractValidator<ReceptionistCreateDto>
{
    public ReceptionistCreateDtoValidator()
    {
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.Email)
            .Email();
        RuleFor(command => command.IdOffice)
            .GuidRule();
        RuleFor(command => command.IdPhoto)
            .GuidRule();
    }
}