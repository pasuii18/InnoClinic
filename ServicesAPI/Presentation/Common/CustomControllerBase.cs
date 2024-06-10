using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ServicesAPI.Common;

[ApiController]
public class CustomControllerBase : ControllerBase
{
    public static IActionResult Result(ICustomResult result)
    {
        return new ObjectResult(result)
        {
            StatusCode = (int)result.GetStatusCode()
        };
    }
}