using ECommerceSampleClassLibrary.Exceptions;

namespace ECommerceSample.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class EntityNotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public EntityNotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {

                await _next(httpContext);
            }
            catch (EntityNotFoundException ex)
            {
                httpContext.Response.StatusCode = 404;
                var message = ex.Message;
                httpContext.Response.Headers.Append("Error", message);
            }
            catch (Exception)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.Headers.Append("Error", "Something went wrong:(");
            }
        }
    }

    public static class EntityNotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UseEntityNotFoundMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EntityNotFoundMiddleware>();
        }
    }
}
