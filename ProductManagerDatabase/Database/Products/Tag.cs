#nullable disable

namespace ProductManagerDatabase.Database.Products
{

    public class Tag
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public string HexColour { get; set; }


        public List<Product> Products { get; set; }

    }

}
