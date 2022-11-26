using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aurora.Core.Filters.Exceptions;

public class ExceptionFilter: FilterBase, IExceptionFilter
{
    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        return Task.CompletedTask;
    }

    public void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        if (ex is BusException bs)
        {
            context.Result = Error(bs.Message, bs.Code);
        }
        else
        {
            context.Result = Error("系统错误", 503);
        }
    }
}