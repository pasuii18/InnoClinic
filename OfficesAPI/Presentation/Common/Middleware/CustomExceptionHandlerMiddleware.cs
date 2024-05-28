using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Text.Json;
using Serilog;

namespace Presentation.Common.Middleware;

public class CustomExceptionHandlerMiddleware(
    RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        Log.Logger.Information($"Incoming request: " +
                               $"Method: {context.Request.Method} " +
                               $"Path: {context.Request.Path}");
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
            Log.Logger.Error($"An error occured! " +
                             $"Message: {e.Message}");
        }
        finally
        {
            Log.Information($"Completed request. " +
                            $"Status code: {context.Response.StatusCode}");
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;
        switch (e)
        {
            case KeyNotFoundException keyNotFoundException:
                code = HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new { error = keyNotFoundException.Message });
                break;
            case DuplicateNameException duplicateNameException:
                code = HttpStatusCode.Conflict;
                result = JsonSerializer.Serialize(new { error = duplicateNameException.Message });
                break;
            default:
                result = JsonSerializer.Serialize(new { error = e.Message });
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (result == string.Empty) result = JsonSerializer.Serialize(new { error = e.Message });
        
        return context.Response.WriteAsync(result);
    }
}