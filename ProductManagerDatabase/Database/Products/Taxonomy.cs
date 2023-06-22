#nullable disable

using ProductManagerDatabase.Database.Interfaces;

namespace ProductManagerDatabase.Database.Products
{
    public class Taxonomy:IHasPrimaryKey
    {

        public int Id { get; set; }

        public string PrimaryType { get; set; }

        public string SecondaryType { get; set; }

        public string TertiaryType { get; set; }

        public string QuaternaryType { get; set; }

        void IHasPrimaryKey.SetPrimaryKey<TKeyType>(TKeyType key) => this.Id = int.Parse($"{key}");

    }

}
