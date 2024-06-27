using Application.Common.Dtos.ServiceDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators.ServicesValidators;

public class ServiceUpdateDtoValidator : AbstractValidator<ServiceUpdateDto>
{
    public ServiceUpdateDtoValidator()
    {
        RuleFor(dto => dto.IdService)
            .IsGuid();
        RuleFor(dto => dto.ServiceName)
            .ServiceName();
        RuleFor(dto => dto.Price)
            .Price();
        RuleFor(dto => dto.IdServiceCategory)
            .IsGuid();
    }
}