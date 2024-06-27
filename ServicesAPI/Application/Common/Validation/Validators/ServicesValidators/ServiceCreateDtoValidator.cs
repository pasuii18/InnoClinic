using Application.Common.Dtos.ServiceDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators.ServicesValidators;

public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
{
    public ServiceCreateDtoValidator()
    {
        RuleFor(dto => dto.ServiceName)
            .ServiceName();
        RuleFor(dto => dto.Price)
            .Price();
        RuleFor(dto => dto.IdServiceCategory)
            .IsGuid();
    }
}