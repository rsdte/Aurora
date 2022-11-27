using Aurora.Application.Contracts;
using Aurora.Application.Contracts.Systems;
using Aurora.Application.Contracts.Systems.Dtos.RoleDtos;
using Aurora.Core.Common;
using Aurora.Core.Extensions;
using Aurora.Domain.Shared.Utils;
using Aurora.Domain.Systems.Permissions;
using Aurora.Domain.Systems.RolePermissions;
using Aurora.Domain.Systems.Roles;
using Aurora.Domain.Systems.UserRoles;

namespace Aurora.Application.Systems;

public class RoleAppService: IRoleAppService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IOperator _operator;

    public RoleAppService(
        IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository,
        IOperator @operator,
        IRolePermissionRepository rolePermissionRepository)
    {
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
        _operator = @operator;
        _rolePermissionRepository = rolePermissionRepository;
    }

    /// <inheritdoc />
    public async Task<IList<string>> GetRoleIdsAsync(string userId, string tenantId)
    {
        var userRoles = await _userRoleRepository.GetListAsync(p => p.UserId == userId && p.TenantId == tenantId);
        if (userRoles.IsNullOrEmpty())
            return new List<string>();

        return userRoles.Select(p => p.RoleId).ToList();
    }

    /// <inheritdoc />
    public async Task SaveAsync(RoleSave input)
    {
        await _roleRepository.InsertAsync(new Role
        {
            CreateTime = DateTime.Now,
            CreatorId = _operator.UserId,
            Deleted = false,
            Id = IdHelper.Get(),
            Name = input.RoleName,
            TenantId = input.RoleName,
        });
    }

    /// <inheritdoc />
    public async Task UpdateAsync(RoleUpdate input)
    {
        var role = await _roleRepository.FindAsync(p => p.Id == input.RoleId);
        if (role.IsNullOrEmpty())
            throw new BusException(false, "更新失败, 未找到相关数据", 1001);

        role.Name = input.RoleName;
        role.TenantId = input.TenantId;
        await _roleRepository.UpdateAsync(role);
    }

    /// <inheritdoc />
    public async Task<RoleDto?> GetData(string Id)
    {
        var role = await _roleRepository.FindAsync(p => p.Id == Id);
        if (role.IsNullOrEmpty())
            return null;
        
        return new()
        {
            Id = role.Id,
            Name = role.Name,
            TenantId = role.TenantId
        };
    }

    /// <inheritdoc />
    public async Task UpdatePermission(AddPermissionDto input)
    {
        var list = await _rolePermissionRepository.GetListAsync(p => p.RoleId == input.RoleId);
        if (!list.IsNullOrEmpty())
        {
            await _rolePermissionRepository.DeleteAsync(list);
        }

        var now = DateTime.Now;

        var permissions = await _permissionRepository.GetListAsync(p => input.PermissionIds.Contains(p.Id));

        var data = permissions.Select(p => new RolePermission
        {
            CreateTime = now,
            Id = IdHelper.Get(),
            CreatorId = _operator.UserId,
            Deleted = false,
            PermissionId = p.Id,
            RoleId = input.RoleId,
        }).ToList();

        await _rolePermissionRepository.InsertAsync(data);
    }
}