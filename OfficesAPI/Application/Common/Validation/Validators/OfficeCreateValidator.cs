using Application.Common.Dtos.OfficesDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class OfficeCreateValidator : AbstractValidator<OfficeCreateDto>
{
    public OfficeCreateValidator()
    {
        RuleFor(createOffice => createOffice.Address)
            .Address();

        RuleFor(createOffice => createOffice.RegistryPhoneNumber)
            .RegistryPhoneNumber();

        RuleFor(createOffice => createOffice.IsActive)
            .NotNull().WithMessage("The IsActive field is required.");
        
        RuleFor(createOffice => createOffice.IdPhoto)
            .NotEmpty().WithMessage("The IdPhoto field is required and cannot be an empty GUID.");
    }
}