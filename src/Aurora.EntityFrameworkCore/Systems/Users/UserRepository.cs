using Aurora.Domain.Systems.Users;

namespace Aurora.EntityFrameworkCore.Systems.Users;
public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AuroraDbContext dbContext) : base(dbContext)
    {
    }
}