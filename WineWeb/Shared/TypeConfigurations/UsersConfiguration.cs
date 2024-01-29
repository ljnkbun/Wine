using Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.TypeConfigurations
{
    public class UsersConfiguration : BaseConfiguration<Users>
    {
        public override void Configure(EntityTypeBuilder<Users> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(50);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.UserName).HasMaxLength(100);
            builder.Property(e => e.Password).HasMaxLength(100);
            builder.Property(e => e.Email).HasMaxLength(500);
        }
    }
}
