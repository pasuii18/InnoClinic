﻿using Application.Common.Dtos.Filters;
using FluentValidation;

namespace Application.Common.Validation.Validators.ServicesValidators;

public class ServicesFilterValidator : AbstractValidator<ServicesFilter>
{
    public ServicesFilterValidator()
    {
        RuleFor(dto => dto)
            .ServicesFilter();
    }
}