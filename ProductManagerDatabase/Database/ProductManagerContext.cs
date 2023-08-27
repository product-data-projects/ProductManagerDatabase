using Microsoft.EntityFrameworkCore;
using ProductManagerDatabase.Database.Configuration;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerDatabase.Database
{
    public class ProductManagerContext : DbContext
    {
        public DbSet<Brand> Brands => base.Set<Brand>();
        public DbSet<Cycle> Cycles => base.Set<Cycle>();
        public DbSet<DataPoint> DataPoints => base.Set<DataPoint>();
        public DbSet<Manufacturer> Manufacturers => base.Set<Manufacturer>();
        public DbSet<Product> Products => base.Set<Product>();
        public DbSet<Products.Range> Ranges => base.Set<Products.Range>();
        public DbSet<Status> Statuses => base.Set<Status>();
        public DbSet<Tag> Tags => base.Set<Tag>();
        public DbSet<Taxonomy> Taxonomies => base.Set<Taxonomy>();

        public ProductManagerContext() { }
        public ProductManagerContext(DbContextOptions<ProductManagerContext> options) : base(options) { }
     
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=portainer.ad0.roguelj.co.uk;Database=ProductManager;user id=pm-user;password=076da4a79552;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CycleConfiguration());
            modelBuilder.ApplyConfiguration(new DataPointConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDataPointConfiguration());
            modelBuilder.ApplyConfiguration(new ProductStageConfiguration());
            modelBuilder.ApplyConfiguration(new StageConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new RangeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TaxonomyConfiguration());
        }

    }

}
