using Aurora.Domain.Systems.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.EntityFrameworkCore.Systems.Roles;
internal class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(AuroraDbContext dbContext) : base(dbContext)
    {
    }
}
