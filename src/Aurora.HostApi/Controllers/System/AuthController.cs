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
    
    [HttpPost]
    public async Task<TokenDto> SignIn(SignInDto input)
    {
        return await _authAppService.SignInAsync(input);
    }
}