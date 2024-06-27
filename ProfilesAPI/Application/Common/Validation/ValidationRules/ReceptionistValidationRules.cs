﻿using Application.Common.Dtos.Filters;
using FluentValidation;

namespace Application.Common.Validation.ValidationRules;

public static class ReceptionistValidationRules
{
    public static IRuleBuilder<T, ReceptionistFilters> ReceptionistFilters<T>(this IRuleBuilder<T, ReceptionistFilters> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage("Receptionist filters cannot be null.")
            .ChildRules(filters =>
            {
                filters.RuleFor(f => f.OrderBy)
                    .OrderBy();
                filters.RuleFor(f => f.OrderType)
                    .OrderType();
                filters.RuleFor(f => f.FullName)
                    .FullName();
            });
    }
}