namespace Aurora.Application.Contracts.Systems.Dtos.RoleDtos;

public class RoleSave
{
    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; set; }
    /// <summary>
    /// 租户id
    /// </summary>
    public string TenantId { get; set; }
}