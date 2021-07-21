using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.OData.Dto;
using KommunikaciosTechnikak.OData.Mapping;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using System.Linq;

namespace KommunikaciosTechnikak
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AdventureWorks2019Context>();

            services.AddControllers();

            services.AddOData();

            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseODataBatching();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.Select().Filter().OrderBy().Count().Expand().MaxTop(10);
                endpoints.MapODataRoute(
                    routeName: "odata",
                    routePrefix: "odata",
                    model: GetEdmModel(),
                    batchHandler: new DefaultODataBatchHandler());
            });
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();

            var products = odataBuilder.EntitySet<Product>("Products");
            products.EntityType.Ignore(p => p.Rowguid);
            products.EntityType.Ignore(p => p.ModifiedDate);
            products.EntityType.HasKey(p => p.ProductId);

            odataBuilder.EntitySet<ProductReview>("ProductReviews");
            odataBuilder.EntitySet<ProductModel>("ProductModels");
            odataBuilder.EntitySet<ProductSubcategory>("ProductSubcategories");
            odataBuilder.EntitySet<ProductInventory>("ProductInventory");
            odataBuilder.EntitySet<Location>("Locations");
            odataBuilder.EntitySet<ProductProductPhoto>("ProductProductPhotos");
            odataBuilder.EntitySet<ProductPhoto>("ProductPhotos");
            odataBuilder.EntitySet<ProductVendor>("ProductVendors");
            odataBuilder.EntitySet<Vendor>("Vendors");

            // DTO réteg bevezetése
            odataBuilder.EntitySet<ProductDto>("ProductDto");
            odataBuilder.EntityType<ProductDto>().HasKey(p => p.ProductId);

            return odataBuilder.GetEdmModel();
        }
    }
}
