using Application.Common.ValidationRules;
using FluentValidation;

namespace Application.Services.PatientsFolder.Commands.DeletePatient;

public class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
{
    public DeletePatientCommandValidator()
    {
        RuleFor(command => command.IdPatient)
            .IdPatient();
    }
}