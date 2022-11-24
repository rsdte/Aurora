using Snowflake;

namespace Aurora.Domain.Shared.Utils;
public class IdHelper
{
    private static IdWorker _worker;

    static IdHelper()
    {
        _worker = new IdWorker(1, 1);
    }

    public static string Get() => _worker.NextId().ToString();
}
