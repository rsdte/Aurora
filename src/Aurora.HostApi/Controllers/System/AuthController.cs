using Aurora.Application.Contracts.Systems;
using Aurora.Application.Contracts.Systems.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;

namespace Aurora.HostApi.Controllers.System;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController: ControllerBase
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
    [HttpPost]
    public async Task<TokenDto> SignIn(SignInDto input)
    {
        return await _authAppService.SignInAsync(input);
    }
}