using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProfilesAPI.Common;

public class CustomControllerBase : ControllerBase
{
    public static IActionResult Result(ICustomResult result)
    {
        return new ObjectResult(result)
        {
            StatusCode = result.GetStatusCode()
        };
    }
}