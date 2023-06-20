using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        void IEntityTypeConfiguration<Tag>.Configure(EntityTypeBuilder<Tag> builder)
        {

            // keys
            builder.HasKey(e => e.Id);

            // properties
            builder.Property(p => p.Name).HasMaxLength(16);
            builder.Property(p => p.Description).HasMaxLength(64);
            builder.Property(p => p.HexColour).HasMaxLength(6);

            // indicies
            builder.HasIndex(e => e.Description).IsUnique();
                        
        }

    }

}
