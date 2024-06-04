using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.PatientsFolder.Commands.UpdatePatient;

public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(command => command.IdPatient)
            .IdPatient();
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.PhoneNumber)
            .PhoneNumber();
        RuleFor(command => command.DateOfBirth)
            .DateOfBirth();
        RuleFor(command => command.IdPhoto)
            .IdPhoto();
    }
}