using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.PatientsFolder.Commands.CreatePatient;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
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
            .IdPhoto();
    }
}