using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

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

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class EntityNotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UseEntityNotFoundMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EntityNotFoundMiddleware>();
        }
    }
}
