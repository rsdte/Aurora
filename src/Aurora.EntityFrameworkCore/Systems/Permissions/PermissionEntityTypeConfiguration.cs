using Aurora.Domain.Shared;
using Aurora.Domain.Shared.Systems.Permissions;
using Aurora.Domain.Systems.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.EntityFrameworkCore.Systems.Permissions;

public class PermissionEntityTypeConfiguration : EntityTypeConfigurationBase<Permission>
{
    protected override void OnConfigure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("tb_permission");
        builder.Property(p => p.Icon).HasMaxLength(PermissionConfiguration.IconMaxLength);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(PermissionConfiguration.NameMaxLength);
        builder.Property(p => p.Url).HasMaxLength(PermissionConfiguration.UrlMaxLength);
        builder.Property(p => p.ParentId).HasMaxLength(EntityConfigurationBase.IdMaxLength);
        builder.Property(p => p.Type).IsRequired();
    }
}