namespace Aurora.Core.Common;

public interface IPageQuery
{
    /// <summary>
    /// 字段名称
    /// </summary>
    public string FieldName { get; set; }
    /// <summary>
    /// 字段值
    /// </summary>
    public string FieldValue { get; set; }
    /// <summary>
    /// 搜索时间段的开始时间
    /// </summary>
    public DateTime? StartTime { get; set; }
    /// <summary>
    /// 搜索时间段的结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }
}