using Aurora.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aurora.HostApi.Filters.Results;

public class ResultFilter: FilterBase
{

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await next.Invoke();
        switch (context.Result)
        {
            case EmptyResult:
                context.Result = Success();
                await Task.CompletedTask;
                return;
            case ObjectResult { Value: JsonFormattedResult jr }:
                context.Result = JsonContent(jr);
                break;
            case ObjectResult obj:
                context.Result = Success(obj.Value);
                break;
        }
    }
}