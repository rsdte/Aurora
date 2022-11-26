using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;

namespace Aurora.Core.DependencyInjections;

public  static class DependencyInjectionExtensions
{
    public static IServiceCollection Autowired(this IServiceCollection self)
    {

        var dependencyContext = DependencyContext.Default;

        var assemblies = dependencyContext.CompileLibraries.Where(p => !p.Serviceable)
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(p.Name)))
            .ToList();

        var assemblyTypes =  assemblies.SelectMany(p => p.GetTypes())
            .Where(p=> p.IsClass && !p.IsAbstract && !p.IsInterface)
            .ToList();
      
        assemblyTypes.Where(p=> typeof(IScopedDependency).IsAssignableFrom(p))
            .ToList()
            .ForEach(item =>
            {
                item.GetInterfaces().ToList().ForEach(i => self.AddScoped(i, item));
            });
        
        assemblyTypes.Where(p=> typeof(ITransientDependency).IsAssignableFrom(p))
            .ToList()
            .ForEach(item =>item.GetInterfaces().ToList().ForEach(i => self.AddTransient(i, item)));

        assemblyTypes.Where(p=> typeof(ISingletonDependency).IsAssignableFrom(p))
            .ToList()
            .ForEach(item =>item.GetInterfaces().ToList().ForEach(i => self.AddSingleton(i, item)));

        return self;
    }
}