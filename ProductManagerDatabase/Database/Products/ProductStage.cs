#nullable disable


namespace ProductManagerDatabase.Database.Products
{
    public class ProductStage
    {

        public int Id { get; set; }

        public Product Product { get; set; }

        public Stage Stage { get; set; }

        public DateTimeOffset StageAt { get; set; }

    }

}
