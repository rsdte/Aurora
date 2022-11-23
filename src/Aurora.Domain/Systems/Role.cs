namespace Aurora.Domain.Systems;

public class Role : EntityBase
{
    /// <summary>
    /// 租户id
    /// </summary>
    public string TenantId { get; set; }
    
    /// <summary>
    /// 角色名称
    /// </summary>
    public string Name { get; set; }
    
}