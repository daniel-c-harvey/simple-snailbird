namespace SnailbirdHome.Middleware;

/// <summary>
/// Middleware to handle HTTP HEAD requests according to RFC 9110.
/// HEAD responses must be identical to GET responses, but without the body.
/// Converts HEAD to GET so Blazor Router can match routes, then suppresses body.
/// </summary>
public class HeadRequestMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (HttpMethods.IsHead(context.Request.Method))
        {
            // Convert HEAD to GET so Blazor Router can match the route
            context.Request.Method = HttpMethods.Get;

            // Suppress response body per RFC 9110
            context.Response.Body = Stream.Null;
        }

        await next(context);
    }
}

/// <summary>
/// Extension methods for adding HeadRequestMiddleware to the application pipeline.
/// </summary>
public static class HeadRequestMiddlewareExtensions
{
    public static IServiceCollection AddHeadRequestMiddleware(this IServiceCollection services)
    {
        services.AddTransient<HeadRequestMiddleware>();
        return services;
    }

    public static IApplicationBuilder UseHeadRequestMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HeadRequestMiddleware>();
    }
}
