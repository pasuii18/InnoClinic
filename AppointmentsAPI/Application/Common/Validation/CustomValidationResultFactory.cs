using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace Application.Common.Validation;

public class CustomValidationResultFactory :
    ControllerBase, IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
    {
        var errorMessages = validationProblemDetails.Errors
            .SelectMany(entry => entry.Value)
            .ToList();

        return BadRequest(new CustomResult(false, HttpStatusCode.BadRequest, errorMessages));

    }
}