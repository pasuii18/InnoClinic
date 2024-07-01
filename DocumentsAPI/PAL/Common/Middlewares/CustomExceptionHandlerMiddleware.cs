using System.Net;
using System.Text.Json;
using BAL.Common;

namespace Presentation.Common.Middlewares;

public class CustomExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        return context.Response.WriteAsync(
            JsonSerializer.Serialize(
                new CustomResult<string>(false, HttpStatusCode.InternalServerError, messages: [e.Message])));
    }
}