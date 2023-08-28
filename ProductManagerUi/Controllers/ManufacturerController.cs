using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProductManagerDatabase.Database.Products;
using ProductManagerDatabase.Database;
using DevExtreme.AspNet.Mvc.Builders;

namespace ProductManagerUi.Controllers
{
    public class ManufacturerController : EntityBaseController<Manufacturer, string>
    {


        public ManufacturerController(ProductManagerContext productManagerContext, ILogger<Manufacturer> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Manufacturers);



        protected override void Validate(Manufacturer entity)
        {

        }

    }
}
