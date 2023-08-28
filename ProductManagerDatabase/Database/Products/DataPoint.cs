#nullable disable

using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{

    public class DataPoint
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<ProductDataPoint> ProductDataPoints { get; set; }


    }

}
