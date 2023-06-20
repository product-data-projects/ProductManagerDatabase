#nullable disable

using Microsoft.EntityFrameworkCore;

namespace ProductManagerDatabase.Database.Products
{

    public class Cycle
    {

        public string Name { get; set; }

        public string Description { get; set; }

        [Precision(4, 2)]
        public decimal PriorityIndex { get; set; }

    }

}
