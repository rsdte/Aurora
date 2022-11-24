using Aurora.Domain.Systems.Tenants;
using Aurora.Domain.Systems.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.EntityFrameworkCore.Systems.UserRoles;
internal class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AuroraDbContext dbContext) : base(dbContext)
    {
    }
}