using TheSecretSanta.Domain.Interfaces;
using TheSecretSanta.Domain.Models;

namespace TheSecretSanta.API.Middlewares;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IApplicationUserRepository _repo)
    {
        string apiKey = context.Request.Headers["X-API-Key"];

        if (apiKey == null)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API key is missing");
            return;
        }

        ApplicationUser user = await _repo.GetApplicationUserByApiKey(Guid.Parse(apiKey));

        if (user == null)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid API key");
            return;
        }

        context.Items.Add("ApplicationUser", user);

        await _next(context);
    }
}
