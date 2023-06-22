#nullable disable

using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{
    public class ProductStage:IHasPrimaryKey
    {

        public int Id { get; set; }
        public Product Product { get; set; }

        public Stage Stage { get; set; }

        public DateTimeOffset StageAt { get; set; }

        void IHasPrimaryKey.SetPrimaryKey<TKeyType>(TKeyType key) => this.Id = int.Parse($"{key}");

    }

}
