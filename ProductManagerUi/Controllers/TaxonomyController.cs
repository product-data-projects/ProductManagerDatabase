using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProductManagerDatabase.Database.Products;
using ProductManagerDatabase.Database;
using DevExtreme.AspNet.Mvc.Builders;

namespace ProductManagerUi.Controllers
{
    public class TaxonomyController : EntityBaseController<Taxonomy, int>
    {


        public TaxonomyController(ProductManagerContext productManagerContext, ILogger<Taxonomy> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Taxonomies);

        protected override void Validate(Taxonomy entity)
        {

        }

    }

}
