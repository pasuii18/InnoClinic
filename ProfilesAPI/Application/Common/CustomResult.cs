using Application.Interfaces;

namespace Application.Common;

public class CustomResult : ICustomResult
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public CustomResult(bool isSuccess = false, string message = "", int statusCode = 0)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message;
    }

    public CustomResult(bool isSuccess, string message, int statusCode, object? data) 
        : this(isSuccess, message, statusCode)
    {
        Data = data;
    }

    public int GetStatusCode()
    {
        return StatusCode != 0 ? StatusCode : 500;
    }
}
