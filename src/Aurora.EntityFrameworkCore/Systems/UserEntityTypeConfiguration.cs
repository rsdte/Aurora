using Aurora.Domain.Shared;
using Aurora.Domain.Shared.Systems.Users;
using Aurora.Domain.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.EntityFrameworkCore.Systems;

public class UserEntityTypeConfiguration: EntityTypeConfigurationBase<User>
{
    protected override void OnConfigure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable($"tb_user");

        builder.Property(p => p.UserName).IsRequired().HasMaxLength(UserConfiguration.UserNameMaxLength);
        builder.Property(p => p.Password).IsRequired().HasMaxLength(UserConfiguration.PasswordMaxLength);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(UserConfiguration.EmailMaxLength);
    }
}