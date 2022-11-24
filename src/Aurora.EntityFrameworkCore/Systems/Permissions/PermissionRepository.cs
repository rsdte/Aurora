using Aurora.Domain.Systems.Permissions;

namespace Aurora.EntityFrameworkCore.Systems.Permissions;
public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
{
    public PermissionRepository(AuroraDbContext dbContext) : base(dbContext)
    {
    }
}
