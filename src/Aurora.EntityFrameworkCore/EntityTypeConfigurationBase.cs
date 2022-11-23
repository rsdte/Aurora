using Aurora.Domain;
using Aurora.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.EntityFrameworkCore;

public abstract class EntityTypeConfigurationBase<T>: IEntityTypeConfiguration<T>
    where T: EntityBase
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(p => p.Id).IsRequired().HasMaxLength(EntityConfigurationBase.IdMaxLength);

        builder.Property(p => p.CreateTime).IsRequired().HasDefaultValue(DateTime.Now);

        builder.Property(p => p.CreatorId).IsRequired().HasMaxLength(EntityConfigurationBase.IdMaxLength);

        builder.Property(p => p.Deleted).IsRequired().HasDefaultValue(false);

        OnConfigure(builder);
    }

    protected abstract void OnConfigure(EntityTypeBuilder<T> builder);

}