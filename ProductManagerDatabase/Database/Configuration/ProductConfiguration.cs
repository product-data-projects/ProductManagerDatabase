using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {

            // table
            builder.ToTable(b => b.IsTemporal());


            // keys
            builder.HasKey(b => b.Id);


            // properties
            builder.Property(p => p.Model).HasMaxLength(64).IsRequired();
            builder.Property(p => p.RevisionCode).HasMaxLength(4).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Weight).HasPrecision(20, 4);
            builder.Property(p => p.Height).HasPrecision(20, 4);
            builder.Property(p => p.Width).HasPrecision(20, 4);
            builder.Property(p => p.Depth).HasPrecision(20, 4);


            // indicies
            builder.HasIndex(new [] {nameof(Product.Model), nameof(Product.RevisionCode)}).IsUnique();


            // relationships
            builder.HasMany(e => e.Manufacturers).WithMany(e => e.Products);
            builder.HasMany(e => e.Tags).WithMany(e => e.Products);

           
        }

    }

}
