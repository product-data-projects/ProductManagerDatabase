#nullable disable


namespace ProductManagerDatabase.Database.Products
{

    public class Stage 
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProductStage> ProductStages { get; set; }


    }

}
