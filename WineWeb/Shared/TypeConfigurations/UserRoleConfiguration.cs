using Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.TypeConfigurations
{
    public class UserRoleConfiguration : BaseConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(50);
            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasOne(s => s.Users)
              .WithMany(g => g.UserRoles)
              .HasForeignKey(s => s.UsersId);

            builder.HasOne(s => s.Role)
              .WithMany(g => g.UserRoles)
              .HasForeignKey(s => s.RoleId);
        }
    }
}
