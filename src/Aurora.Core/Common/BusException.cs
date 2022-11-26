namespace Aurora.Core.Common;

public class BusException: Exception
{
    /// <summary>
    /// 错误码
    /// </summary>
    public int Code { get; }
    
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess { get; }
    
    /// <summary>
    /// 附带新
    /// </summary>
    public string Message { get; }
    
    public BusException(bool isSuccess, string message, int code)
    {
        IsSuccess = isSuccess;
        Message = message;
        Code = code;
    }
    
    public BusException(string message, int code):this(false, message, code){}
    
    public BusException(string message): this(false, message, 1001){}
    
}