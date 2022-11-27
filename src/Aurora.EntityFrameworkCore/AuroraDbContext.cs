using Aurora.Core.Extensions;
using Aurora.Domain.Shared;
using Aurora.Domain.Systems.Permissions;
using Aurora.Domain.Systems.Roles;
using Aurora.Domain.Systems.UserRoles;
using Aurora.Domain.Systems.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aurora.EntityFrameworkCore;

public class AuroraDbContext: DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<Permission> Permissions { get; set; }
    
    public AuroraDbContext(DbContextOptions<AuroraDbContext> options): base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #if DEBUG
        optionsBuilder.EnableDetailedErrors();
        #endif
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuroraDbContext).Assembly);
        ConfigureSoftDelete(modelBuilder);
    }
    
    /// <summary>
    /// 过滤器增加软删除过滤
    /// </summary>
    /// <param name="builder"></param>
    private void ConfigureSoftDelete(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var prop = entityType.FindProperty("Deleted");
            if(prop.IsNullOrEmpty())
                continue;

            if (prop.DeclaringEntityType.ClrType == typeof(bool))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "Deleted");

                // 添加过滤器
                var body = Expression.Equal(
                    Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool) }, parameter,
                        Expression.Constant("Deleted")),
                    Expression.Constant(false));
                builder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
            }
        }
    }
}