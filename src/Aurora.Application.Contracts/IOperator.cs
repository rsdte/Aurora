using Aurora.Core.DependencyInjections;

namespace Aurora.Application.Contracts;

public interface IOperator: IScopedDependency
{
    public string UserName { get; }
    public string TanentId { get;}
    public string UserId { get; }
}