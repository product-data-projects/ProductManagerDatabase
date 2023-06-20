using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    public class TaxonomyConfiguration : IEntityTypeConfiguration<Taxonomy>
    {

        void IEntityTypeConfiguration<Taxonomy>.Configure(EntityTypeBuilder<Taxonomy> builder)
        {

            // keys
            builder.HasKey(e => e.Id);

            // properties
            builder.Property(p => p.PrimaryType).HasMaxLength(32);
            builder.Property(p => p.SecondaryType).HasMaxLength(32);
            builder.Property(p => p.TertiaryType).HasMaxLength(32);
            builder.Property(p => p.QuaternaryType).HasMaxLength(32);

            // indicies
            var propertyNamesForIndex = new List<string>
            {
                nameof(Taxonomy.PrimaryType), 
                nameof(Taxonomy.SecondaryType), 
                nameof(Taxonomy.TertiaryType), 
                nameof(Taxonomy.QuaternaryType)
            };

            builder.HasIndex(propertyNamesForIndex.ToArray()).IsUnique();
                        
        }

    }

}
