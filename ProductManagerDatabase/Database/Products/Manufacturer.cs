#nullable disable


namespace ProductManagerDatabase.Database.Products
{

    public class Manufacturer
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }

    }

}
