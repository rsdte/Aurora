namespace Aurora.Domain.Systems.RolePermissions;

public class RolePermission : EntityBase
{
    /// <summary>
    /// 角色id
    /// </summary>
    public string RoleId { get; set; }
    /// <summary>
    /// 权限 id
    /// </summary>
    public string PermissionId { get; set; }
}