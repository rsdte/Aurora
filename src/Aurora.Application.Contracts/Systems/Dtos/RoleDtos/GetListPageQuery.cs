using Aurora.Core.Common;

namespace Aurora.Application.Contracts.Systems.Dtos.RoleDtos;

public class GetListPageQuery: IPageQuery
{
    /// <summary>
    /// 角色名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 用户id
    /// </summary>
    public string UserId { get; set; }

    /// <inheritdoc />
    public string FieldName { get; set; }
    
    /// <inheritdoc />
    public string FieldValue { get; set; }
    
    /// <inheritdoc />
    public DateTime? StartTime { get; set; }
    
    /// <inheritdoc />
    public DateTime? EndTime { get; set; }
}