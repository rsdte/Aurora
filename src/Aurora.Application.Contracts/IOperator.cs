using Aurora.Core.DependencyInjections;

namespace Aurora.Application.Contracts;

public interface IOperator: IScopedDependency
{
    public string UserName { get; }
    public string TenantId { get;}
    public string UserId { get; }
    
    public List<string> RoleIds { get; }
    
    public bool IsLogin { get; }
}