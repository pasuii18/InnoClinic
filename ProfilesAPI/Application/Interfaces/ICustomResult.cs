using System.Net;

namespace Application.Interfaces;

public interface ICustomResult
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public object? Data { get; set; }

    public HttpStatusCode GetStatusCode();
}