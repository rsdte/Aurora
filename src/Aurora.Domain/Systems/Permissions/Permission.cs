using Aurora.Domain.Shared.Systems.Permissions;

namespace Aurora.Domain.Systems.Permissions;

/// <summary>
/// 权限
/// </summary>
public class Permission : EntityBase
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 类型 （0：菜单，1：页面，2：按钮）
    /// </summary>
    public PermissionType Type { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 上级id
    /// </summary>
    public string? ParentId { get; set; }
}