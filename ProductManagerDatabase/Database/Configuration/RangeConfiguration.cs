using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;
using Range = ProductManagerDatabase.Database.Products.Range;

namespace ProductManagerDatabase.Database.Configuration
{
    public class RangeConfiguration : IEntityTypeConfiguration<Range>
    {
        void IEntityTypeConfiguration<Range>.Configure(EntityTypeBuilder<Range> builder)
        {

            // keys
            builder.HasKey(e => e.Id);

            // properties
            builder.Property(p => p.Name).HasMaxLength(32);
            builder.Property(p => p.Description).HasMaxLength(64);

            // indicies
            builder.HasIndex(e => e.Description).IsUnique();
        }

    }

}
