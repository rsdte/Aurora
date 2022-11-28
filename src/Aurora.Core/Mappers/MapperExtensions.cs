using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using System.Runtime.Loader;

namespace Aurora.Core.Mappers;

public static class MapperExtensions
{
    /// <summary>
    /// 自动映射.
    /// </summary>
    /// <param name="self"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddMapper(this IServiceCollection self, Action<IMapperConfigurationExpression> config = null)
    {
        var mappers = new Dictionary<Type, Type[]>();
        
        var dependencyContext = DependencyContext.Default;

        var assemblies = dependencyContext.CompileLibraries.Where(p => !p.Serviceable)
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(p.Name)))
            .ToList();
        
        assemblies.ForEach(assembly =>
        {
            foreach(var type in assembly.GetTypes())
            {
                if (type.GetCustomAttribute(typeof(MapperAttribute)) is MapperAttribute m)
                {
                    mappers.TryAdd(type, m.TargetTypes);
                }
            }
        });

        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            foreach(var item in mappers)
            {
                foreach(var destination in item.Value)
                {
                    cfg.CreateMap(item.Key, destination);
                }
            }
            cfg.AddMaps(assemblies);
            config?.Invoke(cfg);
        });

        self.AddSingleton(mapperConfiguration.CreateMapper());
        
        return self;
    }
}


