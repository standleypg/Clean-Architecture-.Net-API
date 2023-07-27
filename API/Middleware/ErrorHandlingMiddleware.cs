using System.Net;
using System.Text.Json;

namespace API.Middleware;

/// <summary>
/// Error handling middleware
/// </summary> <summary>
/// this middleware is one of the ways to handle errors in the application, 
/// in case want to use it, please enable it in Program.cs
/// </summary>
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new { error = ex.Message });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}
