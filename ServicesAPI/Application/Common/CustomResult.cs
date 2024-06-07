using System.Net;
using Application.Interfaces;

namespace Application.Common;

public class CustomResult(bool isSuccess, HttpStatusCode statusCode) : ICustomResult
{
    public bool IsSuccess { get; set; } = isSuccess;
    public HttpStatusCode StatusCode { get; set; } = statusCode;
    public object? Data { get; set; }

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