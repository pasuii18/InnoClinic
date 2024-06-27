using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProfilesAPI.Common;

[ApiController]
public class CustomControllerBase : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    public static IActionResult Result(ICustomResult result)
    {
        return new ObjectResult(result)
        {
            StatusCode = (int)result.GetStatusCode()
        };
    }
}