using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using ProductManagerDatabase.Database;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ProductManagerDatabase.Database.Products;

namespace ProductManagerUi.Controllers
{
    public abstract class EntityBaseController<T> : Controller where T : class, new()
    {

        protected ProductManagerContext ProductManagerContext { get; }


        protected EntityBaseController(ProductManagerContext productManagerContext)
        {
            this.ProductManagerContext = productManagerContext ?? throw new ArgumentNullException(nameof(productManagerContext));
        }


        protected async Task<LoadResult> GetEntities(DataSourceLoadOptions loadOptions, IQueryable<T> queryableEntities)
        {

            // provide an IQueryable (or descendant) to the DataSourceLoader, along with the load options.
            // this will allow EntityFramework to dynamically generate the SQL, doing the filtering on the SQL Server,
            // rather than the client.

            return await DataSourceLoader.LoadAsync(queryableEntities, loadOptions);

        }

        protected async Task<T?> InsertEntity(string values)
        {

            var entity = new T();

            JsonConvert.PopulateObject(values, entity);

            this.Validate(entity);
            base.TryValidateModel(entity);

            if (base.ModelState.IsValid)
            {

                // add the entity to the db and save.
                await this.ProductManagerContext!.AddAsync<T>(entity);
                await this.ProductManagerContext!.SaveChangesAsync();

                return entity;

            }
            else
            {
                return null;

            }

        }


        protected abstract void Validate(T entity);
    }

}
