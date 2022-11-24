using Aurora.Domain.Systems.Roles;
using Aurora.Domain.Systems.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.EntityFrameworkCore.Systems.Tenants;
internal class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
{
    public TenantRepository(AuroraDbContext dbContext) : base(dbContext)
    {
    }
}