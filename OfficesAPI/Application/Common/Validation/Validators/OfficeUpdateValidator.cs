using Application.Common.Dtos.OfficesDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators;

public class OfficeUpdateValidator : AbstractValidator<OfficeUpdateDto>
{
    public OfficeUpdateValidator()
    {
        RuleFor(createOffice => createOffice.IdOffice)
            .IdOffice();
        
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