using Application.Common.Dtos.DoctorDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.DoctorValidators;

public class DoctorUpdateDtoValidator : AbstractValidator<DoctorUpdateDto>
{
    public DoctorUpdateDtoValidator()
    {
        RuleFor(command => command.IdDoctor)
            .GuidRule();
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
            .GuidRule();
        RuleFor(command => command.IdSpecialization)
            .GuidRule();
        RuleFor(command => command.IdOffice)
            .GuidRule();
    }
}