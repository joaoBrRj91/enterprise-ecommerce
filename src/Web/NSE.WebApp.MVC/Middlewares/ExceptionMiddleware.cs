using System.Net;

namespace NSE.WebApp.MVC.Middlewares;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (HttpRequestException ex)
        {
            HandleRequestExceptionAsync(httpContext, ex);
        }
    }

    private static void HandleRequestExceptionAsync(HttpContext context, HttpRequestException httpRequestException)
    {
        if (httpRequestException.StatusCode == HttpStatusCode.Unauthorized)
        {
            context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
            return;
        }

        context.Response.StatusCode = (int)httpRequestException.StatusCode!;
    }

}
