using Aurora.Application.Contracts;
using Microsoft.AspNetCore.Http;

namespace Contracts.Application;

public class Operator : IOperator
{
    public string UserName { get; }

    public string TanentId { get; }

    public string UserId { get; }


    public Operator(HttpContextAccessor httpContextAccessor)
    {

    }
}