using System.Net;
using System.Text.Json.Serialization;

namespace BAL.Common.Interfaces;

public interface ICustomResult<T>
{
    public bool IsSuccess { get; set; }
    [JsonIgnore] 
    public HttpStatusCode StatusCode { get; set; }
    public T? Data { get;  set; }
    public string[]? Messages { get;  set; }

    public int GetStatusCode();
}