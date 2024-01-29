using Core.EntityConfigurations;
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
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
