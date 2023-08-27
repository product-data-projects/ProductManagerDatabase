using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductManagerDatabase.Database;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerUi.Controllers
{
    public class ProductController : EntityBaseController<Product>
    {


        public ProductController(ProductManagerContext productManagerContext) : base(productManagerContext) { }

        public IActionResult Index() => this.View();


        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Products);


        public async Task<IActionResult> PostAsync(string values)
        {

            var entity = await this.InsertEntity(values);

            return entity is null ? base.BadRequest(base.ModelState) : base.Ok(entity);

        }

        protected override void Validate(Product entity)
        {
           
        }

    }

}
