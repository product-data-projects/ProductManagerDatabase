using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using ProductManagerDatabase.Database;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerUi.Controllers
{
    public class StageController : EntityBaseController<Stage, string>
    {


        public StageController(ProductManagerContext productManagerContext, ILogger<Stage> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Stages);

        protected override void Validate(Stage entity)
        {

        }

    }
}
