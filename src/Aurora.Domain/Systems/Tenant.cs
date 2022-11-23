namespace Aurora.Domain.Systems;

public class Tenant: EntityBase
{
    /// <summary>
    /// 租户名称
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 父级租户
    /// </summary>
    public string ParentId { get; set; }
}