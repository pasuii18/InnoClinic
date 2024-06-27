using Application.Common.Dtos.DoctorDtos;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Common.Validation.Validators.DoctorValidators;

public class CreateDoctorDtoValidator : AbstractValidator<CreateDoctorDto>
{
    public CreateDoctorDtoValidator()
    {
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
        RuleFor(command => command.IdAccount)
            .GuidRule();
        RuleFor(command => command.IdSpecialization)
            .GuidRule();
        RuleFor(command => command.IdOffice)
            .IdOffice();
    }
}