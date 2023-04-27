using System.Net;

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

        var result = $"pau loco \n{HttpStatusCode.InternalServerError.ToString()} {ex.Message} {ex?.InnerException?.Message}";
        //context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}