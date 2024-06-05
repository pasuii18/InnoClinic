using Application.Common.ValidationRules;
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