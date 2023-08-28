using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{

    public class Product : IHasSoftDelete
    {

        // primary key
        public int Id { get; set; }


        // properties - simple
        public string Model { get; set; } 
        public string RevisionCode { get; set; }
        public string? Notes { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }

        // properties - dimensions
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Depth { get; set; }
        public decimal? Weight { get; set; }


        // date system properties
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }


        // navigation - single
        public Brand? Brand { get; set; }
        public int? BrandId { get; set; }

        public Range? Range { get; set; }
        public int? RangeId { get; set; }

        public Taxonomy? Taxonomy { get; set; }
        public int? TaxonomyId { get; set; }

        public Cycle? Cycle { get; set; }
        public int? CycleId { get; set; }

        public Status? Status { get; set; }
        public int? StatusId { get; set; }


        // navigation - many
        public virtual List<Manufacturer> Manufacturers { get; } = new List<Manufacturer>();
        public virtual List<Tag> Tags { get; } = new List<Tag>();
        public virtual List<ProductStage> ProductStages { get; } = new List<ProductStage>();
        public virtual List<ProductDataPoint> ProductDataPoints { get; } = new List<ProductDataPoint>();

    }

}
