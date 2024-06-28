using Application.Common.Dtos.AppointmentsDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class CreateAppointmentDtoValidator : AbstractValidator<CreateAppointmentDto>
{
    public CreateAppointmentDtoValidator()
    {
        RuleFor(rule => rule.UpdateSlotStatusDto.Date)
            .IsDateOnly();
        RuleFor(rule => rule.UpdateSlotStatusDto.StartTime)
            .IsTimeOnly();
        RuleFor(rule => rule.UpdateSlotStatusDto.EndTime)
            .IsTimeOnly();
        RuleFor(rule => rule.IdPatient)
            .IsGuid();
        RuleFor(rule => rule.IdDoctor)
            .IsGuid();
        RuleFor(rule => rule.IdService)
            .IsGuid();
    }
}