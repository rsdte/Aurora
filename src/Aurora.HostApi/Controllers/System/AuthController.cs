using Aurora.Application.Contracts;
using Aurora.Application.Contracts.Systems;
using Aurora.Application.Contracts.Systems.Dtos.AuthDtos;
using Aurora.HostApi.Filters.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Aurora.HostApi.Controllers.System;

/// <summary>
/// 用户认证
/// </summary>
[OpenApiTag("用户验证")]
public class AuthController: ApiControllerBase
{
    private readonly IAuthAppService _authAppService;

    public AuthController(IAuthAppService authAppService)
    {
        _authAppService = authAppService;

    }
    
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input">登录用户信息</param>
    /// <returns></returns>
    [HttpPost,AllowAnonymous]
    public async Task<TokenDto> SignIn(SignInDto input)
    {
        return await _authAppService.SignInAsync(input);
    }

    /// <summary>
    /// 测试
    /// </summary>
    /// <param name="input"></param>
    [HttpPost, ApiPermission]
    public async Task SignOut(TokenDto input)
    {
        await Task.CompletedTask;
    }
}