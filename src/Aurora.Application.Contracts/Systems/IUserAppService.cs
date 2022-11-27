using Aurora.Application.Contracts.Systems.Dtos.UserDtos;

namespace Aurora.Application.Contracts.Systems;

public interface IUserAppService: IAppService
{
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <returns></returns>
    Task<UserDto> GetDataAsync(string userName);

    /// <summary>
    /// 为指定用户添加指定角色
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task AddRoleAsync(AddRoleToUser input);
}