using BAL.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Common;

[ApiController]
public class CustomControllerBase : ControllerBase
{
    public IActionResult Result<T>(ICustomResult<T> result)
    {
        return new ObjectResult(result)
        {
            StatusCode = result.GetStatusCode()
        };
    }
}