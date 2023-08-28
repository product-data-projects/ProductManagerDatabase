using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using ProductManagerDatabase.Database;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerUi.Controllers
{
    public class ProductController : EntityBaseController<Product, int>
    {


        public ProductController(ProductManagerContext productManagerContext, ILogger<Product> logger) : base(productManagerContext, logger) { }
         

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Products);

        protected override void Validate(Product entity)
        {
           
        }

    }

}
