using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductManagerDatabase.Database;
using System;

namespace ProductManagerUi.Controllers
{
    public abstract class EntityBaseController<TEntity, TPrimaryKeyType> : Controller where TEntity : class, new()
    {

        // injected services
        protected ProductManagerContext ProductManagerContext { get; }

        protected ILogger<TEntity> Logger { get; }


        // constructor
        protected EntityBaseController(ProductManagerContext productManagerContext, ILogger<TEntity> logger)
        {
            this.ProductManagerContext = productManagerContext ?? throw new ArgumentNullException(nameof(productManagerContext));
            this.Logger = logger;
        }


        /// <summary>
        /// Route to the default table view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => this.View();


        /// <summary>
        /// Route to create a new entity.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public async Task<IActionResult> PostAsync(string values)
        {

            // create the new entity, and populate it's values
            var entity = new TEntity();
            JsonConvert.PopulateObject(values, entity);


            // validate
            this.Validate(entity);
            base.TryValidateModel(entity);

            if (base.ModelState.IsValid)
            {

                // add the entity to the db and save.
                await this.ProductManagerContext!.AddAsync<TEntity>(entity);
                await this.ProductManagerContext!.SaveChangesAsync();

                return base.Ok(entity);

            }
            else
            {
                return base.BadRequest(base.ModelState);

            }

        }


        /// <summary>
        /// Route to update an entity.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public async Task<IActionResult> PutAsync(TPrimaryKeyType key, string values)
        {

            if(this.ProductManagerContext.Find<TEntity>(key) is TEntity entity)
            {
                JsonConvert.PopulateObject(values, entity);

                this.Validate(entity);
                base.TryValidateModel(entity);

                if (base.ModelState.IsValid)
                {

                    // add the entity to the db and save.
                    this.ProductManagerContext!.Update(entity);
                    await this.ProductManagerContext!.SaveChangesAsync();

                    return base.Ok(entity);

                }
                else
                {
                    return base.BadRequest(base.ModelState);

                }

            }
            else
            {
                return base.NotFound();
            }
       
        }


        /// <summary>
        /// Route to delete an entity.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(TPrimaryKeyType key)
        {

            if (await this.ProductManagerContext!.FindAsync(typeof(TEntity), key) is TEntity entity)
            {

                try
                {
                    this.ProductManagerContext.Remove(entity);
                    await this.ProductManagerContext.SaveChangesAsync();

                    return base.Ok();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    this.Logger.LogError(ex, "Exception during {method}", "Delete");
                    return this.DbError(ex);
                }
                catch(DbUpdateException ex)
                {
                    this.Logger.LogError(ex, "Exception during {method}", "Delete");
                    return this.DbError(ex);
                }

            }
            else 
            { 
                return base.NotFound(); 
            }

        }


        protected async Task<LoadResult> GetEntities(DataSourceLoadOptions loadOptions, IQueryable<TEntity> queryableEntities)
        {

            // provide an IQueryable (or descendant) to the DataSourceLoader, along with the load options.
            // this will allow EntityFramework to dynamically generate the SQL, doing the filtering on the SQL Server,
            // rather than the client.

            return await DataSourceLoader.LoadAsync(queryableEntities, loadOptions);

        }

        private IActionResult DbError(DbUpdateException ex)
        {

            // TODO: fix - better error reporting
            if(ex.InnerException is null)
            {
                return base.BadRequest(ex.Message);
            }
            else
            {
                return base.BadRequest(ex.InnerException.Message);
            }
           
        }


        // must be implemented by derived class to provide fine-tuned validation for the entity type
        protected abstract void Validate(TEntity entity);



    }

}
