using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Text.Json;
using Serilog;

namespace Presentation.Common.Middleware;

public class CustomExceptionHandlerMiddleware(
    RequestDelegate next, 
    ILogger<CustomExceptionHandlerMiddleware> _logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;
        switch (e)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new { error = validationException.Message });
                break;
            case KeyNotFoundException keyNotFoundException:
                code = HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new { error = keyNotFoundException.Message });
                break;
            case DuplicateNameException duplicateNameException:
                code = HttpStatusCode.Conflict;
                result = JsonSerializer.Serialize(new { error = duplicateNameException.Message });
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (result == string.Empty) result = JsonSerializer.Serialize(new { error = e.Message });
        Log.Logger.Error($"An error occured! Code: {code}, Message: {e.Message}");
        
        return context.Response.WriteAsync(result);
    }
}