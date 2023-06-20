using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database.Configuration
{
    public class ProductStageConfiguration : IEntityTypeConfiguration<ProductStage>
    {
        void IEntityTypeConfiguration<ProductStage>.Configure(EntityTypeBuilder<ProductStage> builder)
        {
            builder.HasOne<Stage>(e => e.Stage).WithMany(e=> e.ProductStages);
            builder.HasOne<Product>(e => e.Product).WithMany(e => e.ProductStages);
        }

    }

}
