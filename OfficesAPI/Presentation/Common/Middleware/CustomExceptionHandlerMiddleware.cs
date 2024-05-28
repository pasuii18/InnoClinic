using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Text.Json;
using Application.Common;
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
                            $"Status code: {context.Response.StatusCode}" +
                            $"Method: {context.Request.Method} " + 
                            $"Path: {context.Request.Path}");
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var code = HttpStatusCode.InternalServerError;
        switch (e)
        {
            case KeyNotFoundException:
                code = HttpStatusCode.NotFound;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(new CustomResult(false, e.Message, (int)code)));

    }
}