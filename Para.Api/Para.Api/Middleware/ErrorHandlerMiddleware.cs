using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Para.Api.Middleware;


public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            // before controller invoke
            await next.Invoke(context);
            // after controller invoke
        }
        catch (Exception ex)
        {

            await HandleExceptionAsync(context, ex);
        }

    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected

        if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
        else if (exception is NotFoundException) code = HttpStatusCode.NotFound;
        else if (exception is ArgumentException) code = HttpStatusCode.BadRequest;
        else if (exception is ValidationException) code = HttpStatusCode.BadRequest;

        var result = JsonSerializer.Serialize(new { error = exception.Message, code });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

}