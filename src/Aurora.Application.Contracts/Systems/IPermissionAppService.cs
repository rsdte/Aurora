using Aurora.Application.Contracts.Systems.Dtos.PermissionDtos;

namespace Aurora.Application.Contracts.Systems;

public interface IPermissionAppService : IAppService
{
    /// <summary>
    /// 获取指定用户的权限
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <returns></returns>
    Task<IList<PermissionDto>> GetListAsyncByUserId(string userId);

    /// <summary>
    /// 获取指定角色权限
    /// </summary>
    /// <param name="roleId">角色</param>
    /// <returns></returns>
    Task<IList<PermissionDto>> GetListAsyncByRoleId(string roleId);
}