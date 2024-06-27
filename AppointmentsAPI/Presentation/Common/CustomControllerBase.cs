using Application.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace ServicesAPI.Common;

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