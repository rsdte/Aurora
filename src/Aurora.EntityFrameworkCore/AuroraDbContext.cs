using Aurora.Domain.Shared;
using Aurora.Domain.Systems;
using Microsoft.EntityFrameworkCore;

namespace Aurora.EntityFrameworkCore;

public class AuroraDbContext: DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<Permission> Permissions { get; set; }
    
    public AuroraDbContext(DbContextOptions<AuroraDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuroraDbContext).Assembly);
    }
}