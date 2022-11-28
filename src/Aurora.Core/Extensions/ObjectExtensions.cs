using System.Collections;

namespace Aurora.Core.Extensions;

public static class ObjectExtensions
{
    public static bool IsNullOrEmpty(this object? self)
    {
        if (self is null)
            return true;

        if (self is string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        if (self is IEnumerable<object> t)
        {
            return !t.Any();
        }

        return false;
    }
}