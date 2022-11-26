using Aurora.Domain.Shared;
using Aurora.Domain.Systems.RolePermissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.EntityFrameworkCore.Systems.RolePermissions;

public class RolePermissionEntityTypeConfiguration : EntityTypeConfigurationBase<RolePermission>
{
    protected override void OnConfigure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("tb_role_permission");
        builder.Property(p => p.RoleId).IsRequired().HasMaxLength(EntityConfigurationBase.IdMaxLength);
        builder.Property(p => p.PermissionId).IsRequired().HasMaxLength(EntityConfigurationBase.IdMaxLength);
    }
}