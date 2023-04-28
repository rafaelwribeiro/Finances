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
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        if(ex is NotFoundException)
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        

        var error = new ErrorContract();
        error.StatusCode = context.Response.StatusCode;
        error.Message = $"{ex.Message} {ex?.InnerException?.Message}";
        var result = JsonConvert.SerializeObject(error);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
    }
}