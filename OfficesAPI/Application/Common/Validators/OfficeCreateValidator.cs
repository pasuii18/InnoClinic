using Domain.Common.Dtos.OfficesDtos;
using FluentValidation;

namespace Application.Common.Validators;

public class OfficeCreateValidator : AbstractValidator<OfficeCreateDto>
{
    public OfficeCreateValidator()
    {
        RuleFor(createOffice => createOffice.Address)
            .NotEmpty().WithMessage("The office address is required.")
            .MaximumLength(100).WithMessage("The office address must not exceed 100 characters.")
            .Matches(@"^[a-zA-Z]{2,20},\s*[a-zA-Z0-9]{2,20},\s*[a-zA-Z0-9]{1,5},\s*[a-zA-Z0-9]{1,5}$")
            .WithMessage("The address is invalid. It must be in the format: 'Street, City, House, Office'.");

        RuleFor(createOffice => createOffice.RegistryPhoneNumber)
            .NotEmpty().WithMessage("The registry phone number is required.")
            .MaximumLength(20).WithMessage("The registry phone number must not exceed 20 characters.")
            .Matches(@"^\+\d{7,15}$").WithMessage("The registry phone number must contain between 7 and 15 digits after the plus sign.");

        RuleFor(createOffice => createOffice.IsActive)
            .NotNull().WithMessage("The IsActive field is required.");
        
        RuleFor(createOffice => createOffice.IdPhoto)
            .NotEmpty().WithMessage("The IdPhoto  field is required and cannot be an empty GUID.");
    }
}