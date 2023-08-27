#nullable disable

namespace ProductManagerDatabase.Database.Products
{

    public class Product
    {

        // primary key
        public int Id { get; set; }


        // properties - simple
        public string Model { get; set; }
        public string RevisionCode { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }


        // properties - dimensions
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public decimal Weight { get; set; }


        // date system properties
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }


        // navigation - single
        public Brand Brand { get; set; }
        public Range Range { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public Cycle Cycle { get; set; }
        public Status Status { get; set; }


        // navigation - many
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Tag> Tags { get; set; }
        public List<ProductStage> ProductStages { get; set; }
        public List<ProductDataPoint> ProductDataPoints { get; set; }

    }

}
