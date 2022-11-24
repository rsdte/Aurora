using Microsoft.Extensions.Options;

namespace Aurora.HostApi.Options;

public class DatabaseOption
{
    public string Provider { get; set; }
    
    public string ConnectionString { get; set; }
    
}