using Aurora.Application.Contracts.Systems.Dtos.AuthDtos;

namespace Aurora.Application.Contracts.Systems;

public interface IAuthAppService: IAppService
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <returns></returns>
    Task<TokenDto> SignInAsync(SignInDto input);

    /// <summary>
    /// 退出
    /// </summary>
    /// <returns></returns>
    Task SignOutAsync();
}