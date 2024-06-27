using Application.Interfaces;
using System.Net;

namespace Application.Common;

public class CustomResult : ICustomResult
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public object? Data { get; set; }

    public CustomResult(bool isSuccess = false,  HttpStatusCode statusCode = 0)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
    }

    public CustomResult(bool isSuccess, HttpStatusCode statusCode, object? data) 
        : this(isSuccess, statusCode)
    {
        Data = data;
    }

    public HttpStatusCode GetStatusCode()
    {
        return StatusCode != 0 ? StatusCode : HttpStatusCode.InternalServerError;
    }
}
