using Application.Common;
using System.Net;
using System.Text.Json;

namespace ProfilesAPI.Common.Middleware;

public class CustomExceptionHandlerMiddleware(
    RequestDelegate next)
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
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        return context.Response.WriteAsync(
            JsonSerializer.Serialize(new CustomResult(false, e.Message, HttpStatusCode.InternalServerError)));
    }
}