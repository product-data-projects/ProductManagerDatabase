#nullable disable

using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{

    public class Brand : IHasPrimaryKey
    {
        public string Name { get; set; }

        public string Description { get; set; }

        void IHasPrimaryKey.SetPrimaryKey<TKeyType>(TKeyType key) => this.Name = key.ToString();
   
    }

}
