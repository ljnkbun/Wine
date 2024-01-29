using Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.TypeConfigurations
{
    public class LocationConfiguration : BaseConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(50);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
