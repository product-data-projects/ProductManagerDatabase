#nullable disable

using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{

    public class Tag:IHasPrimaryKey
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public string HexColour { get; set; }


        public List<Product> Products { get; set; }

        void IHasPrimaryKey.SetPrimaryKey<TKeyType>(TKeyType key) => this.Id = int.Parse($"{key}");

    }

}
