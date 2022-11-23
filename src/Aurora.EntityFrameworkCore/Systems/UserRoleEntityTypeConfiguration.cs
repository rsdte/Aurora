using Aurora.Domain.Shared;
using Aurora.Domain.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.EntityFrameworkCore.Systems;

public class UserRoleEntityTypeConfiguration: EntityTypeConfigurationBase<UserRole>
{
    protected override void OnConfigure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("db_user_role");

        builder.Property(p => p.TenantId).HasMaxLength(EntityConfigurationBase.IdMaxLength).IsRequired();
        builder.Property(p => p.UserId).HasMaxLength(EntityConfigurationBase.IdMaxLength).IsRequired();
        builder.Property(p => p.RoleId).HasMaxLength(EntityConfigurationBase.IdMaxLength).IsRequired();
    }
}