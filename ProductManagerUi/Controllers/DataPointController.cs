using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProductManagerDatabase.Database.Products;
using ProductManagerDatabase.Database;
using DevExtreme.AspNet.Mvc.Builders;

namespace ProductManagerUi.Controllers
{
    public class DataPointController : EntityBaseController<DataPoint, int>
    {


        public DataPointController(ProductManagerContext productManagerContext, ILogger<DataPoint> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.DataPoints);



        protected override void Validate(DataPoint entity)
        {

        }

    }
}
