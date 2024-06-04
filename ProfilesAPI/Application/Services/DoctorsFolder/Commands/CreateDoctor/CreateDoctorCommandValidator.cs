using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.DoctorsFolder.Commands.CreateDoctor;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorCommandValidator()
    {
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.DateOfBirth)
            .DateOfBirth();
        RuleFor(command => command.Email)
            .EmailAddress();
        RuleFor(command => command.CareerStartYear)
            .CareerStartYear();
        RuleFor(command => command.Status)
            .Status();
        RuleFor(command => command.IdAccount)
            .IdAccount();
        RuleFor(command => command.IdSpecialization)
            .IdSpecialization();
        RuleFor(command => command.IdOffice)
            .IdOffice();
    }
}