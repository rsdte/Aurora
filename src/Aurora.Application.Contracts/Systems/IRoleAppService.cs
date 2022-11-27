using Aurora.Application.Contracts.Systems.Dtos.RoleDtos;

namespace Aurora.Application.Contracts.Systems;

public interface IRoleAppService: IAppService
{
    /// <summary>
    /// 获取用户角色id
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <param name="tenantId">租户id</param>
    /// <returns></returns>
    Task<IList<string>> GetRoleIdsAsync(string userId, string tenantId);

    /// <summary>
    /// 保存新角色
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task SaveAsync(RoleSave input);

    /// <summary>
    /// 更新新数据.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync(RoleUpdate input);

    /// <summary>
    /// 获取指定角色
    /// </summary>
    /// <param name="Id">角色id</param>
    /// <returns></returns>
    Task<RoleDto?> GetData(string Id);

    /// <summary>
    /// 更新角色权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdatePermission(AddPermissionDto input);

}