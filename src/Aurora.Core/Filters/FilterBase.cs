using Aurora.Core.Fillters.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json.Serialization;

namespace Aurora.Core.Filters;

public abstract class FilterBase : IAsyncActionFilter
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
        return JsonContent(new JsonResult
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
        return JsonContent(new JsonResult
        {
            Success = true,
            Data = data,
            Code = 200
        });
    }

    public ContentResult Error(string msg, int code)
    {
        return JsonContent(new JsonResult
        {
            Success = false,
            Message = msg,
            Code = code
        });
    }
}