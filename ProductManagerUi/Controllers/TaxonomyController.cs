using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProductManagerDatabase.Database.Products;
using ProductManagerDatabase.Database;
using DevExtreme.AspNet.Mvc.Builders;
using DevExtreme.AspNet.Mvc.Factories;

namespace ProductManagerUi.Controllers
{
    public class TaxonomyController : EntityBaseController<Taxonomy, int>
    {


        public TaxonomyController(ProductManagerContext productManagerContext, ILogger<Taxonomy> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Taxonomies);

        protected override void Validate(Taxonomy entity)
        {

        }

        public static void ProvideLookup(DataGridColumnLookupBuilder lookup)
        {
            lookup.DataSource(DataSourceFactory)
                    .DisplayExpr(nameof(Taxonomy.PrimaryType))
                    .ValueExpr(nameof(Taxonomy.Id));
        }

        public static OptionsOwnerBuilder DataSourceFactory(DataSourceFactory dataSourceFactory)
        {
            return dataSourceFactory
                  .Mvc()
                  .Controller("Taxonomy")
                  .LoadAction("Get")
                  .Key(nameof(Taxonomy.Id))
                  .LoadMode(DataSourceLoadMode.Processed)
                  .CacheRawData(false);
        }

    }

}
