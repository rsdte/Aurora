namespace Aurora.Core.Fillters.Results;

public class JsonResult
{
    public int Code { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    public object Data { get; set; }
}