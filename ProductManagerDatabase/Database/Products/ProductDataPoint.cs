#nullable disable

using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{
    public class ProductDataPoint:IHasPrimaryKey
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public DataPoint DataPoint { get; set; }

        public string Data { get; set; }

        void IHasPrimaryKey.SetPrimaryKey<TKeyType>(TKeyType key) => this.Id = int.Parse($"{key}");

    }

}
