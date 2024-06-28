using Application.Common.Dtos.ResultDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators.ResultValidators;

public class UpdateResultDtoValidator : AbstractValidator<UpdateResultDto>
{
    public UpdateResultDtoValidator()
    {
        RuleFor(x => x.Complaints)
            .IsDoctorResult();
        RuleFor(x => x.Conclusion)
            .IsDoctorResult();
        RuleFor(x => x.Recommendations)
            .IsDoctorResult();
    }
}