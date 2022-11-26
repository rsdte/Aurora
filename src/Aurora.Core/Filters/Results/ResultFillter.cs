using Aurora.Core.Fillters.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aurora.Core.Filters.Results;

public class ResultFilter: FilterBase
{

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        switch (context.Result)
        {
            case EmptyResult:
                context.Result = Success();
                await Task.CompletedTask;
                return;
            case ObjectResult { Value: JsonResult jr }:
                context.Result = JsonContent(jr);
                break;
            case ObjectResult obj:
                context.Result = Success(obj.Value);
                break;
        }
    }
}