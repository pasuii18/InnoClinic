using Application.Common.Validation;
using Application.Common.Validation.ValidationRules;
using FluentValidation;

namespace Application.Services.DoctorsFolder.Commands.UpdateDoctorStatus;

public class UpdateDoctorStatusCommandValidator : AbstractValidator<UpdateDoctorStatusCommand>
{
    public UpdateDoctorStatusCommandValidator()
    {
        RuleFor(command => command.IdDoctor)
            .IdDoctor();
        RuleFor(command => command.Status)
            .Status();
    }
}