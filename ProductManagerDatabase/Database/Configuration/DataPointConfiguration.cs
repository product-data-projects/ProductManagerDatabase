using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    public class DataPointConfiguration : IEntityTypeConfiguration<DataPoint>
    {
        void IEntityTypeConfiguration<DataPoint>.Configure(EntityTypeBuilder<DataPoint> builder)
        {

            // keys
            builder.HasKey(e => e.Id);

            // properties
            builder.Property(p => p.Description).HasMaxLength(64);

            // indicies
            builder.HasIndex(e => e.Description).IsUnique();
        }

    }

}
