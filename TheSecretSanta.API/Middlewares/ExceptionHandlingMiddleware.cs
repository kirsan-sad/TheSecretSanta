using System.Net;
using System.Text.Json;
using TheSecretSanta.Domain.Exeptions;
using TheSecretSanta.Domain.Models;

namespace TheSecretSanta.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        _logger.LogError(ex.Message);

        var code = ex switch
        {
            NotFoundException _ => HttpStatusCode.NotFound,
            BadRequestException _ => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var errors = new List<string> { ex.Message };

        var result = JsonSerializer.Serialize(ApiResult<string>.Failure(code, errors));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}
