using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        void IEntityTypeConfiguration<Status>.Configure(EntityTypeBuilder<Status> builder)
        {

            // keys
            builder.HasKey(e => e.Id);

            // properties
            builder.Property(p => p.Name).HasMaxLength(32);
            builder.Property(p => p.Description).HasMaxLength(32);
            builder.Property(p => p.PriorityIndex).HasPrecision(4, 2);

            // indicies
            builder.HasIndex(e => e.Description).IsUnique();

            
        }
    }
}
