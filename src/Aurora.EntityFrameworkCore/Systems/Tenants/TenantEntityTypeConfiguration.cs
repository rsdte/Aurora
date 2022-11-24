using Aurora.Domain.Shared;
using Aurora.Domain.Shared.Systems.Tenants;
using Aurora.Domain.Systems.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.EntityFrameworkCore.Systems.Tenants;

public class TenantEntityTypeConfiguration : EntityTypeConfigurationBase<Tenant>
{
    protected override void OnConfigure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("tb_tenant");

        builder.Property(p => p.Name).IsRequired().HasMaxLength(TenantConfiguration.NameMaxLength);
        builder.Property(p => p.ParentId).HasMaxLength(EntityConfigurationBase.IdMaxLength);
    }
}