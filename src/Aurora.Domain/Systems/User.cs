namespace Aurora.Domain.Systems;

public class User : EntityBase
{
    /// <summary>
    /// 租户id
    /// </summary>
    public string TenantId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; }
    
}