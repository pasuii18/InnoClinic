namespace Application.Interfaces;

public interface ICustomResult
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public int GetStatusCode();
}