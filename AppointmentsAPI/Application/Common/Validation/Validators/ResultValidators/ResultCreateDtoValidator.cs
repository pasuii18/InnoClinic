using Application.Common.Dtos.ResultDtos;
using FluentValidation;

namespace Application.Common.Validation.Validators.ResultValidators;

public class ResultCreateDtoValidator : AbstractValidator<ResultCreateDto>
{
    public ResultCreateDtoValidator()
    {
        RuleFor(x => x.Complaints)
            .IsDoctorResult();
        RuleFor(x => x.Conclusion)
            .IsDoctorResult();
        RuleFor(x => x.Recommendations)
            .IsDoctorResult();
        RuleFor(x => x.IdAppointment)
            .IsGuid();
    }
}