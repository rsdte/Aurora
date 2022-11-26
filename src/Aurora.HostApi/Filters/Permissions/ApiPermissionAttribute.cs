using Aurora.Application.Contracts;
using Aurora.Core.Common;
using Aurora.Domain.Systems.Permissions;
using Aurora.Domain.Systems.RolePermissions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace Aurora.HostApi.Filters.Permissions;

public class ApiPermissionAttribute : FilterBase
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var url = context.HttpContext.Request.Path;

        var serviceProvider = context.HttpContext.RequestServices;
        var _operator = serviceProvider.GetService<IOperator>();
        var _rolePermissionRepository = serviceProvider.GetService<IRolePermissionRepository>();
        var _permissionRepository = serviceProvider.GetService<IPermissionRepository>();
        if (!_operator.IsLogin)
            throw new AuthenticationException();
        if (_operator.RoleIds is null || !_operator.RoleIds.Any())
            throw new BusException(false, "没有权限", 1001);

        var permissions = await (from a in _rolePermissionRepository.GetIQueryable()
            join b in _permissionRepository.GetIQueryable() on a.PermissionId equals b.Id
            where _operator.RoleIds.Contains(a.RoleId)
            select b.Url).ToListAsync();
        if (!permissions.Contains(url))
            throw new BusException(false, "没有权限", 1001);
    }
}