using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        void IEntityTypeConfiguration<Manufacturer>.Configure(EntityTypeBuilder<Manufacturer> builder)
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
