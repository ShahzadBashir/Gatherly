using Gatherly.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Gatherly.Api.Middleware;

public class ExceptionHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
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
            await ConvertException(context, ex);
        }
    }

    private Task ConvertException(HttpContext context, Exception ex) 
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

        context.Response.ContentType = "application/json";

        var result = string.Empty;

        switch (ex)
        {
            case ValidationException validationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException.ValidationErrors);
                break;

            case BadRequestException badRequestException: 
                httpStatusCode = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;

            case NotFoundException notFoundException: 
                httpStatusCode = HttpStatusCode.NotFound;
                break;

            case Exception notFoundException:
                httpStatusCode = HttpStatusCode.BadRequest; 
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;

        if(result == string.Empty)
        {
            result = JsonSerializer.Serialize(new { error = ex.Message });
        }

        return context.Response.WriteAsync(result);
    }
}
