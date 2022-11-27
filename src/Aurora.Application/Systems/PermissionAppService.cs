using Aurora.Application.Contracts.Systems;
using Aurora.Application.Contracts.Systems.Dtos.PermissionDtos;
using Aurora.Core.Common;
using Aurora.Core.Extensions;
using Aurora.Domain.Shared.Systems.Permissions;
using Aurora.Domain.Systems.Permissions;
using Aurora.Domain.Systems.RolePermissions;
using Aurora.Domain.Systems.UserRoles;
using Microsoft.EntityFrameworkCore;

namespace Aurora.Application.Systems;

public class PermissionAppService : IPermissionAppService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public PermissionAppService(
        IPermissionRepository permissionRepository,
        IRolePermissionRepository rolePermissionRepository,
        IUserRoleRepository userRoleRepository)
    {
        _permissionRepository = permissionRepository;
        _rolePermissionRepository = rolePermissionRepository;
        _userRoleRepository = userRoleRepository;
    }

    /// <inheritdoc />
    public async Task<IList<PermissionDto>> GetListAsyncByUserId(string userId)
    {
        var userRoles = await _userRoleRepository.GetListAsync(p => p.UserId == userId);
        var roleIds = userRoles?.Select(p => p.RoleId).ToList();
        if (roleIds.IsNullOrEmpty())
            throw new BusException("未找到相关数据");

        var permissions = await (from r in _rolePermissionRepository.GetIQueryable()
            join p in _permissionRepository.GetIQueryable() on r.PermissionId equals p.Id
            where roleIds.Contains(p.Id)
            select p).ToListAsync();
        var permissionIds = permissions.Select(p => p.Id).Union(permissions.Select(p => p.ParentId)).ToList();

        var list = await _permissionRepository.GetListAsync(p => permissionIds.Contains(p.Id));

        var data = list.Select(p => new PermissionDto
        {
            Id = p.Id,
            Name = p.Name,
            Icon = p.Icon,
            Type = p.Type,
            Url = p.Url,
            ParentId = p.ParentId
        }).ToList();

        foreach(var item in data)
        {
            if(item.ParentId.IsNullOrEmpty())
                continue;
            item.Children = data.Where(p => p.ParentId == item.Id).ToList();
        }

        return data.Where(p => p.Type == PermissionType.Menu && p.ParentId.IsNullOrEmpty()).ToList();
    }

    /// <inheritdoc />
    public async Task<IList<PermissionDto>> GetListAsyncByRoleId(string roleId)
    {
        var permissions = await (from r in _rolePermissionRepository.GetIQueryable()
            join p in _permissionRepository.GetIQueryable() on r.PermissionId equals p.Id
            where roleId == p.Id
            select p).ToListAsync();
        var permissionIds = permissions.Select(p => p.Id).Union(permissions.Select(p => p.ParentId)).ToList();

        var list = await _permissionRepository.GetListAsync(p => permissionIds.Contains(p.Id));

        var data = list.Select(p => new PermissionDto
        {
            Id = p.Id,
            Name = p.Name,
            Icon = p.Icon,
            Type = p.Type,
            Url = p.Url,
            ParentId = p.ParentId
        }).ToList();

        foreach(var item in data)
        {
            if(item.ParentId.IsNullOrEmpty())
                continue;
            item.Children = data.Where(p => p.ParentId == item.Id).ToList();
        }

        return data.Where(p => p.Type == PermissionType.Menu && p.ParentId.IsNullOrEmpty()).ToList();
    }
}