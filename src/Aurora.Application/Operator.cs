using Aurora.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Aurora.Application;

public class Operator : IOperator
{
    public string UserName { get; }

    public string TenantId { get; }

    public string UserId { get; }
    
    public List<string> RoleIds { get; }

    public bool IsLogin { get; }
    
    public Operator(IHttpContextAccessor httpContextAccessor)
    {
        var claims = httpContextAccessor.HttpContext.User?.Claims;
        IsLogin = false;
        if (claims != null && claims.Any())
        {
            UserName = claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;

            UserId = claims.FirstOrDefault(p => p.Type == "Id").Value;
            TenantId = claims.FirstOrDefault(p => p.Type == "TenantId").Value;
            var roleIds = claims.FirstOrDefault(p => p.Type == "RoleIds").Value;
            if (!string.IsNullOrWhiteSpace(roleIds))
            {
                RoleIds = roleIds.Split(',').ToList();
            }

            IsLogin = !string.IsNullOrEmpty(UserId);
        }
    }
}