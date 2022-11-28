using System.Reflection;

namespace Aurora.Core.Extensions;

public static class TypeExtensions
{
    public static bool HasAttribute<T>(this Type self)
        where T : Attribute
    {
        return self.GetCustomAttribute(typeof(T)) != null;
    }
}