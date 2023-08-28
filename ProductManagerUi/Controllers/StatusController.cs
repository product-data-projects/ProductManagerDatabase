using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using ProductManagerDatabase.Database;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerUi.Controllers
{
    public class StatusController : EntityBaseController<Status, string>
    {


        public StatusController(ProductManagerContext productManagerContext, ILogger<Status> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Statuses);

        protected override void Validate(Status entity)
        {

        }

    }
}
