using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using ProductManagerDatabase.Database;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerUi.Controllers
{
    public class BrandController : EntityBaseController<Brand, string>
    {


        public BrandController(ProductManagerContext productManagerContext, ILogger<Brand> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Brands);

        public static void ProvideLookup(DataGridColumnLookupBuilder lookup)
        {
            lookup.DataSource(d => d.Mvc().Controller("Brand").LoadAction("Get").Key(nameof(Brand.Id)))
                    .DisplayExpr(nameof(Brand.Name))
                    .ValueExpr(nameof(Brand.Id));
        }

        protected override void Validate(Brand entity)
        {

        }


    }

}
