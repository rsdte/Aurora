using Aurora.Domain.Systems.RolePermissions;

namespace Aurora.EntityFrameworkCore.Systems.RolePermissions;

public class RolePermissionRepository: RepositoryBase<RolePermission>, IRolePermissionRepository
{

    public RolePermissionRepository(AuroraDbContext dbContext) : base(dbContext)
    {
    }
}