using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    internal class ProductDataPointConfiguration : IEntityTypeConfiguration<ProductDataPoint>
    {
        void IEntityTypeConfiguration<ProductDataPoint>.Configure(EntityTypeBuilder<ProductDataPoint> builder)
        {
            builder.HasOne<DataPoint>(e => e.DataPoint).WithMany(e => e.ProductDataPoints);
            builder.HasOne<Product>(e => e.Product).WithMany(e => e.ProductDataPoints);
        }
    }
}
