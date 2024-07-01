using System.Net;
using BAL.Common.Interfaces;

namespace BAL.Common;

public class CustomResult<T>(bool isSuccess, HttpStatusCode statusCode) : ICustomResult<T>
{
    public bool IsSuccess { get; set; } = isSuccess;
    public HttpStatusCode StatusCode { get; set; } = statusCode;
    public T? Data { get; set; }
    public string[]? Messages { get; set; }

    public CustomResult(bool isSuccess, HttpStatusCode statusCode, T? data) 
        : this(isSuccess, statusCode)
    {
        Data = data;
    }
    public CustomResult(bool isSuccess, HttpStatusCode statusCode, string[]? messages) 
        : this(isSuccess, statusCode)
    {
        Messages = messages;
    }
    
    public int GetStatusCode() => 
        StatusCode != 0 ? (int)StatusCode : (int)HttpStatusCode.InternalServerError;
}