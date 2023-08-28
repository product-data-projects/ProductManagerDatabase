using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using ProductManagerDatabase.Database;
using Range = ProductManagerDatabase.Database.Products.Range;

namespace ProductManagerUi.Controllers
{
    public class RangeController : EntityBaseController<Range, string>
    {


        public RangeController(ProductManagerContext productManagerContext, ILogger<Range> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Ranges);

        protected override void Validate(Range entity)
        {

        }

        public static void ProvideLookup(DataGridColumnLookupBuilder lookup)
        {
            lookup.DataSource(d => d.Mvc().Controller("Range").LoadAction("Get").Key(nameof(Range.Id)))
                    .DisplayExpr(nameof(Range.Name))
                    .ValueExpr(nameof(Range.Id));
        }


    }

}
