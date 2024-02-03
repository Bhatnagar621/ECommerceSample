using ECommerceSampleClassLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceSample.Filters
{
    public class InventoryCheckFilter: Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InsufficientInventoryException)
            {
                context.HttpContext.Response.StatusCode = 400; //bad request
                var message = context.Exception.Message;
                context.Result = new JsonResult(new { error = message });
            }
        }
    }
}
