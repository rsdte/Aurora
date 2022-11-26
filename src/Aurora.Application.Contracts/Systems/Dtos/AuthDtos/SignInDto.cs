using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aurora.Application.Contracts.Systems.Dtos.AuthDtos;

public class SignInDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    [Required,Description("用户名")]
    public string UserName { get; set; }
    
    /// <summary>
    /// 密码
    /// </summary>
    [Required,Description("密码")]
    public string Password { get; set; }
}