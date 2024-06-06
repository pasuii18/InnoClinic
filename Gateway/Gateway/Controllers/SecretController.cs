using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretController : ControllerBase
{
    [HttpGet("/secret")]
    [Authorize]
    public string ScopeGatewayAccess()
    {
        return "Gateway answer!";
    }
}