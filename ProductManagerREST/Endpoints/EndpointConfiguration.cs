using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagerDatabase.Database;
using ProductManagerDatabase.Database.Interfaces;
using ProductManagerDatabase.Database.Products;
using System.Reflection;
using Range = ProductManagerDatabase.Database.Products.Range;

namespace ProductManagerREST.Endpoints
{
    public static partial class EndpointConfiguration
    {
        public static void ConfigureMinimalApi(WebApplication app)
        {

            ConfigureRouteGroup<Brand, string>(app.MapGroup("/brand").WithTags("Brand"));
            ConfigureRouteGroup<Cycle, string>(app.MapGroup("/cycle").WithTags("Cycle"));
            ConfigureRouteGroup<DataPoint, int>(app.MapGroup("/datapoint").WithTags("DataPoint"));
            ConfigureRouteGroup<Manufacturer, string>(app.MapGroup("/manufacturer").WithTags("Manufacturer"));
            ConfigureRouteGroup<Product,int>(app.MapGroup("/product").WithTags("Product"));
            ConfigureRouteGroup<ProductDataPoint,int>(app.MapGroup("/product-datapoint").WithTags("ProductDataPoint"));
            ConfigureRouteGroup<ProductStage,int>(app.MapGroup("/product-stage").WithTags("ProductStage"));
            ConfigureRouteGroup<Range, string>(app.MapGroup("/range").WithTags("Range"));
            ConfigureRouteGroup<Stage,string>(app.MapGroup("/stage").WithTags("Stage"));
            ConfigureRouteGroup<Status,string>(app.MapGroup("/status").WithTags("Status"));
            ConfigureRouteGroup<Tag,int>(app.MapGroup("/tag").WithTags("Tag"));
            ConfigureRouteGroup<Taxonomy, int>(app.MapGroup("/taxonomy").WithTags("Taxonomy"));

        }


        public static void ConfigureRouteGroup<T, TKeyType>(RouteGroupBuilder routeGroupBuilder) where T : class, IHasPrimaryKey, new()
        {

            routeGroupBuilder.MapGet("/", GetAll<T>);
            routeGroupBuilder.MapGet("/{primaryKey}", Get<T, TKeyType>);
            routeGroupBuilder.MapPost("/create", Create<T>);
            routeGroupBuilder.MapPut("/update/{primaryKey}", Update<T, TKeyType>);

            routeGroupBuilder.MapDelete("/destroy/{primaryKey}", Destroy<T, TKeyType>);

        }

        public static void ConfigureRouteGroupWithSoftDelete<T, TKeyType>(RouteGroupBuilder routeGroupBuilder) where T : class, IHasPrimaryKey, IHasSoftDelete, new()
        {

            ConfigureRouteGroup<T, TKeyType>(routeGroupBuilder);
            routeGroupBuilder.MapDelete("/delete/{primaryKey}", Delete<T, TKeyType>);

        }

        static async Task<Results<Ok<List<T>>, NoContent, ProblemHttpResult>> GetAll<T>([FromServices] DbContext dbContext, [FromServices] ILogger logger) where T : class, new()
        {

            try
            {
                var result = await dbContext.Set<T>().ToListAsync();
                if (result.Count == 0)
                {
                    return TypedResults.NoContent();
                }
                else
                {
                    return TypedResults.Ok(result);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.Problem();
            }

        }

        static async Task<Results<Ok<T>, NotFound, ProblemHttpResult>> Get<T, TKeyType>(TKeyType name, [FromServices] DbContext dbContext, [FromServices] ILogger logger) where T : class, new()
        {

            try
            {
                return await dbContext.Set<T>().FindAsync(name) is T entity ? TypedResults.Ok(entity) : TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.Problem();
            }

        }

        static async Task<Results<Ok, ProblemHttpResult>> Create<T>([FromServices] DbContext dbContext, [FromServices] ILogger logger, [FromBody] T entity) where T : class
        {

            try
            {
                await dbContext.Set<T>().AddAsync(entity);
                await dbContext.SaveChangesAsync();

                return TypedResults.Ok();

            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.Problem();
            }

        }

        static async Task<Results<Ok, NotFound, ProblemHttpResult>> Update<T, TKeyType>(TKeyType primaryKey, [FromServices] DbContext dbContext, [FromServices] ILogger logger, [FromBody] T entity) where T : class, IHasPrimaryKey
        {

            try
            {

                dbContext.Set<T>().Update(entity);
                await dbContext.SaveChangesAsync();

                return TypedResults.Ok();

            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.Problem();
            }

        }
        static async Task<Results<Ok, BadRequest>> Destroy<T, TKeyType>([FromServices] DbContext dbContext, TKeyType primaryKey, [FromServices] ILogger logger) where T : class, IHasPrimaryKey, new()
        {
            try
            {
                var entity = new T();
                entity.SetPrimaryKey<TKeyType>(primaryKey);

                var brand = dbContext.Set<T>().Attach(entity);
                brand.State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
                return TypedResults.Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.BadRequest();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.BadRequest();
            }

        }

        static async Task<Results<Ok, BadRequest>> Delete<T, TKeyType>([FromServices] DbContext dbContext, TKeyType primaryKey, [FromServices] ILogger logger) where T : class, IHasSoftDelete, IHasPrimaryKey, new()
        {
            try
            {
                var entity = new T();
                entity.SetPrimaryKey<TKeyType>(primaryKey);
                entity.DeletedAt = DateTimeOffset.UtcNow;

                var brand = dbContext.Set<T>().Attach(entity);
                await dbContext.SaveChangesAsync();
                return TypedResults.Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.BadRequest();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Exception during {entity} {operation}", typeof(T).Name, MethodBase.GetCurrentMethod()?.Name);
                return TypedResults.BadRequest();
            }

        }

    }

}