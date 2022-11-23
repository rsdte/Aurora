using Aurora.Domain.Shared;
using Aurora.Domain.Shared.Systems.Roles;
using Aurora.Domain.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.EntityFrameworkCore.Systems;

public class RoleEntityTypeConfiguration:EntityTypeConfigurationBase<Role>
{
    protected override void OnConfigure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable($"tb_role");
        builder.Property(p => p.Name).IsRequired().HasMaxLength(RoleConfiguration.RoleNameMaxLength);
        builder.Property(p => p.TenantId).IsRequired().HasMaxLength(EntityConfigurationBase.IdMaxLength);
    }
}