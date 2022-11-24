namespace Aurora.Domain.Systems.UserRoles;

public class UserRole : EntityBase
{
    /// <summary>
    /// 租户id
    /// </summary>
    public string TenantId { get; set; }

    /// <summary>
    /// 用户id
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 角色 id
    /// </summary>
    public string RoleId { get; set; }
}