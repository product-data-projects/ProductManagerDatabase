#nullable disable


namespace ProductManagerDatabase.Database.Products
{
    public class ProductDataPoint
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public DataPoint DataPoint { get; set; }

        public string Data { get; set; }


    }

}
