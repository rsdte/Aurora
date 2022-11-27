using Aurora.Application.Contracts;
using Aurora.Application.Contracts.Systems;
using Aurora.Application.Contracts.Systems.Dtos.AuthDtos;
using Aurora.Core.Common;
using Aurora.Core.Configurations;
using Aurora.Domain.Systems.UserRoles;
using Aurora.Domain.Systems.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aurora.Application.Systems;

public class AuthAppService: IAuthAppService
{
    private readonly JwtConfig _jwtConfig;
    private readonly IUserAppService _userAppService;
    private readonly IRoleAppService _roleAppService;

    public AuthAppService(
        IOptions<JwtConfig> jwtConfig, 
        IUserAppService userAppService, IRoleAppService roleAppService)
    {
        _userAppService = userAppService;
        _roleAppService = roleAppService;
        _jwtConfig = jwtConfig.Value;

    }
    
    /// <inheritdoc />
    public async Task<TokenDto> SignInAsync(SignInDto input)
    {
        var user = await _userAppService.GetDataAsync(input.UserName);
        if (user is null)
            throw new BusException("未找到相关用户");

        if (user.Password != input.Password)
            throw new BusException("账户或者密码不正确");

        var roleIds = await _roleAppService.GetRoleIdsAsync(user.Id, user.TenantId);

        var claims = new[] {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("Id", user.Id.ToString()),
            new Claim("RoleIds", String.Join(",", roleIds)),
            new Claim("TenantId", user.TenantId),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var jwtToken = new JwtSecurityToken(_jwtConfig.Issuer, _jwtConfig.Audience, claims, expires: DateTime.Now.AddMinutes(_jwtConfig.AccessExpiration), signingCredentials: credentials);
        return new TokenDto
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken)
        };
    }

    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }
}