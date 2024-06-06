using Application.Common.Dtos.PatientDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.PatientValidators;

public class PatientUpdateDtoValidator : AbstractValidator<PatientUpdateDto>
{
    public PatientUpdateDtoValidator()
    {
        RuleFor(command => command.IdPatient)
            .GuidRule();
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.DateOfBirth)
            .DateOfBirth();
    }
}