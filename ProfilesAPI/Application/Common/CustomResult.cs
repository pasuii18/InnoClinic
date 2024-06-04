using System.Net;
using Application.Interfaces;

namespace Application.Common;

public class CustomResult : ICustomResult
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public CustomResult(bool isSuccess = false, string message = "", HttpStatusCode statusCode = 0)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message;
    }

    public CustomResult(bool isSuccess, string message, HttpStatusCode statusCode, object? data) 
        : this(isSuccess, message, statusCode)
    {
        Data = data;
    }

    public HttpStatusCode GetStatusCode()
    {
        return StatusCode != 0 ? StatusCode : HttpStatusCode.InternalServerError;
    }
}
