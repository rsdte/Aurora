using Aurora.Core.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aurora.HostApi.Filters.Exceptions;

public class ExceptionFilter: FilterBase, IExceptionFilter
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await next.Invoke();
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