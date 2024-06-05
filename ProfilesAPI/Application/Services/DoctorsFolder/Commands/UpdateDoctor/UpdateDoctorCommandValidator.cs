using Application.Common.ValidationRules;
using FluentValidation;

namespace Application.Services.DoctorsFolder.Commands.UpdateDoctor;

public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
{
    public UpdateDoctorCommandValidator()
    {
        RuleFor(command => command.IdDoctor)
            .IdDoctor();
        RuleFor(command => command.FirstName)
            .FirstName();
        RuleFor(command => command.LastName)
            .LastName();
        RuleFor(command => command.MiddleName)
            .MiddleName();
        RuleFor(command => command.DateOfBirth)
            .DateOfBirth();
        RuleFor(command => command.CareerStartYear)
            .CareerStartYear();
        RuleFor(command => command.Status)
            .Status();
        RuleFor(command => command.IdPhoto)
            .IdPhoto();
        RuleFor(command => command.IdSpecialization)
            .IdSpecialization();
        RuleFor(command => command.IdOffice)
            .IdOffice();
    }
}