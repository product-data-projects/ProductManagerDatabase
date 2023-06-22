#nullable disable

using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{

    public class DataPoint:IHasPrimaryKey
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<ProductDataPoint> ProductDataPoints { get; set; }

        void IHasPrimaryKey.SetPrimaryKey<TKeyType>(TKeyType key) => this.Id = int.Parse($"{key}");

    }

}
