using Application.Interfaces;

namespace Application.Common;

public class CustomResult(bool isSuccess, string message, int statusCode) : ICustomResult
{
    public bool IsSuccess { get; set; } = isSuccess;
    public int StatusCode { get; set; } = statusCode;
    public string Message { get; set; } = message;
    public object? Data { get; set; }

    public CustomResult(bool isSuccess, string message, int statusCode, object? data) 
        : this(isSuccess, message, statusCode)
    {
        this.Data = data;
    }
    
    public int GetStatusCode()
    {
        return StatusCode != 0 ? StatusCode : 500;
    }
}