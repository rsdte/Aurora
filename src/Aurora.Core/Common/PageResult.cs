namespace Aurora.Core.Common;

public class PageResult<T>
{
    /// <summary>
    /// 总页数
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// 当前页内容数据量
    /// </summary>
    public int Size { get; set; }
    
    /// <summary>
    /// 当前页
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// 当前页数据
    /// </summary>
    public T Data { get; set; }
    
}