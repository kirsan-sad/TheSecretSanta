using System.Net;

namespace TheSecretSanta.Domain.Models;

public class ApiResult<T>
{
    public bool Succeeded { get; set; }
    public HttpStatusCode Code { get; set; }
    public IEnumerable<string> Errors { get; set; }
    public T Data { get; set; }

    private ApiResult(bool succeeded, HttpStatusCode code, IEnumerable<string> errors, T items)
    {
        Succeeded = succeeded;
        Code = code;
        Errors = errors;
        Data = items;
    }

    public ApiResult() { }

    public static ApiResult<T> Success(T items)
        => new(true, HttpStatusCode.OK, Enumerable.Empty<string>(), items);

    public static ApiResult<T> Failure(HttpStatusCode code, IEnumerable<string> errors)
        => new(false, code, errors, default);
}
