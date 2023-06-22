using Microsoft.AspNetCore.Mvc;
using ProductManagerDatabase.Database;
using ProductManagerDatabase.Database.Products;
using Range = ProductManagerDatabase.Database.Products.Range;

namespace ProductManagerREST.Endpoints
{
    public static partial class EndpointConfiguration
    {
        public static void ConfigureMinimalApi(WebApplication app)
        {

            ConfigureRouteGroup<Brand>(app.MapGroup("/brand").WithTags("Brand"));
            //ConfigureRouteGroup<Cycle>(app.MapGroup("/cycle").WithTags("Cycle"));
            //ConfigureRouteGroup<DataPoint>(app.MapGroup("/datapoint").WithTags("DataPoint"));
            //ConfigureRouteGroup<Manufacturer>(app.MapGroup("/manufacturer").WithTags("Manufacturer"));
            //ConfigureRouteGroup<Product>(app.MapGroup("/product").WithTags("Product"));
            //ConfigureRouteGroup<ProductDataPoint>(app.MapGroup("/product-datapoint").WithTags("ProductDataPoint"));
            //ConfigureRouteGroup<ProductStage>(app.MapGroup("/product-stage").WithTags("ProductStage"));
            //ConfigureRouteGroup<Range>(app.MapGroup("/range").WithTags("Range"));
            //ConfigureRouteGroup<Stage>(app.MapGroup("/stage").WithTags("Stage"));
            //ConfigureRouteGroup<Status>(app.MapGroup("/status").WithTags("Status"));
            //ConfigureRouteGroup<Tag>(app.MapGroup("/tag").WithTags("Tag"));
            //ConfigureRouteGroup<Taxonomy>(app.MapGroup("/taxonomy").WithTags("Taxonomy"));

        }


        //static partial void Get<T>(int id, [FromServices] ProductManagerContext dbContext);
        //static partial void Create<T>([FromBody] T entity);
        //static partial void Update<T>(int id, [FromBody] T entity);
        //static partial void Delete<T>(int id, [FromServices] ProductManagerContext dbContext);

    }
}

