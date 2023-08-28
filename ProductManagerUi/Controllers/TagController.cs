using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProductManagerDatabase.Database.Products;
using ProductManagerDatabase.Database;
using DevExtreme.AspNet.Mvc.Builders;

namespace ProductManagerUi.Controllers
{
    public class TagController : EntityBaseController<Tag, int>
    {


        public TagController(ProductManagerContext productManagerContext, ILogger<Tag> logger) : base(productManagerContext, logger) { }

        public async Task<LoadResult> GetAsync(DataSourceLoadOptions loadOptions) => await this.GetEntities(loadOptions, this.ProductManagerContext.Tags);


        protected override void Validate(Tag entity)
        {

        }

    }
}
