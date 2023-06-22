using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagerDatabase.Database.Interfaces;
using System.Reflection;

namespace ProductManagerREST.Endpoints
{

    public partial class EndpointConfiguration
    {

        public static void ConfigureRouteGroup<T>(RouteGroupBuilder routeGroupBuilder) where T : class, new()
            {
            routeGroupBuilder.MapGet("/", GetAll<T>);
            routeGroupBuilder.MapGet("/{id}", Get<T>);
            // routeGroupBuilder.MapPost("/create", Create<T>);
            // routeGroupBuilder.MapPut("/update/{id}", Update<T>);

            routeGroupBuilder.MapDelete("/destroy/{name:string}", Destroy<T>);

        }

        public static void ConfigureRouteGroupWithSoftDelete<T>(RouteGroupBuilder routeGroupBuilder) where T : class, IHasSoftDelete, new()
        {
            routeGroupBuilder.MapGet("/", GetAll<T>);
            routeGroupBuilder.MapGet("/{id}", Get<T>);
            // routeGroupBuilder.MapPost("/create", Create<T>);
            // routeGroupBuilder.MapPut("/update/{id}", Update<T>);

            routeGroupBuilder.MapDelete("/delete/{name:string}", Delete<T>);
            routeGroupBuilder.MapDelete("/destroy/{name:string}", Destroy<T>);

        }

        static async Task<Results<Ok<List<T>>, NoContent, ProblemHttpResult>> GetAll<T>(DbContext dbContext, ILogger logger) where T : class, new()
        {

            try
            {
                var result = await dbContext.Set<T>().ToListAsync();
                if(result.Count == 0)
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

        static async Task<Results<Ok<T>, NotFound, ProblemHttpResult>> Get<T>(string name, [FromServices] DbContext dbContext, ILogger logger) where T : class, new()
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

        static async Task<Results<Ok, BadRequest>> Destroy<T>(DbContext dbContext, string name, ILogger logger) where T : class, new()
        {
            try
            {
                var brand = dbContext.Set<T>().Attach(new T() { Name = name });
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

        static async Task<Results<Ok, BadRequest>> Delete<T>(DbContext dbContext, string name, ILogger logger) where T : class, IHasSoftDelete, new()
        {
            try
            {
                var brand = dbContext.Set<T>().Attach(new T() { DeletedAt = DateTimeOffset.UtcNow });
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
