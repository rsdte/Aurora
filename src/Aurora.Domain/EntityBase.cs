using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aurora.Domain;

public abstract class EntityBase
{
    /// <summary>
    /// 主键标识
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public bool Deleted { get; set; }
    /// <summary>
    /// 创建人
    /// </summary>
    public string CreatorId { get; set; }
}