namespace Aurora.Core.Common;

public class PageInput<TInput>
    where TInput: IPageQuery
{
    /// <summary>
    /// 请求页内容数量
    /// </summary>
    public int Size { get; set; }
    
    /// <summary>
    /// 请求获取页
    /// </summary>
    public int Index { get; set; }
}