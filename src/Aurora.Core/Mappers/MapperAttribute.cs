namespace Aurora.Core.Mappers;

[AttributeUsage(AttributeTargets.Class)]
public class MapperAttribute: Attribute
{
    public Type[] TargetTypes { get; }

    public MapperAttribute(params Type[] targetTypes)
    {
        TargetTypes = targetTypes;
    }
}