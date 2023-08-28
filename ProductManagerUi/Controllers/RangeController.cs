using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProductManagerDatabase.Database.Products;
using ProductManagerDatabase.Database;
using Range = ProductManagerDatabase.Database.Products.Range;
using DevExtreme.AspNet.Mvc.Builders;

namespace ProductManagerUi.Controllers
{
    public class RangeController : EntityBaseController<Range, string>
    {


        public RangeController(ProductManagerContext productManagerContext, ILogger<Range> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Ranges);

        protected override void Validate(Range entity)
        {

        }

    }

}
