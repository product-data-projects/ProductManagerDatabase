using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProductManagerDatabase.Database.Products;
using ProductManagerDatabase.Database;
using DevExtreme.AspNet.Mvc.Builders;

namespace ProductManagerUi.Controllers
{
    public class CycleController : EntityBaseController<Cycle, string>
    {


        public CycleController(ProductManagerContext productManagerContext, ILogger<Cycle> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Cycles);



        protected override void Validate(Cycle entity)
        {

        }

    }
}
