using Application.Common.Dtos.PatientDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.PatientValidators;

public class PatientCreateDtoValidator : AbstractValidator<PatientCreateDto>
{
    public PatientCreateDtoValidator()
    {
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.PhoneNumber)
            .PhoneNumber();
        RuleFor(command => command.IsLinkedToAccount)
            .NotNull().WithMessage("The IsLinkedToAccount field must not be null.");
        RuleFor(command => command.DateOfBirth)
            .DateOfBirth();
        RuleFor(command => command.IdPhoto)
            .GuidRule();
    }
}