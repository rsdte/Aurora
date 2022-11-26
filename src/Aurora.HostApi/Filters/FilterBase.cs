using Aurora.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aurora.HostApi.Filters;

public abstract class FilterBase : Attribute, IAsyncActionFilter
{
    public abstract Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next);

    public ContentResult JsonContent<T>(T data)
    {
        return new ContentResult
        {
            Content = System.Text.Json.JsonSerializer.Serialize(data),
            StatusCode = 200,
            ContentType = "application/json; charset=utf-8"
        };
    }

    public ContentResult Success(string msg)
    {
        return JsonContent(new JsonFormattedResult
        {
            Success = true,
            Message = msg,
            Code =  200
        });
    }
    
    public ContentResult Success()
    {
        return Success("操作成功");
    }

    public ContentResult Success<T>(T data)
    {
        return JsonContent(new JsonFormattedResult
        {
            Success = true,
            Data = data,
            Code = 200
        });
    }

    public ContentResult Error(string msg, int code)
    {
        return JsonContent(new JsonFormattedResult
        {
            Success = false,
            Message = msg,
            Code = code
        });
    }
}