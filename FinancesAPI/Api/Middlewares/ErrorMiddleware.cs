using System.Net;
using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using Newtonsoft.Json;

namespace FinancesAPI.Api.Middleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate next;
    public ErrorMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var error = new ErrorContract();
        error.Message = $"{ex.Message} {ex?.InnerException?.Message}";

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        if(ex is NotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            error.Message = "Entity not found";
        }

        if(ex is BusinessLogicException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            error.Message = ex.Message;
        }

        error.StatusCode = context.Response.StatusCode;
        var result = JsonConvert.SerializeObject(error);
        return context.Response.WriteAsync(result);
    }
}