using DecouplingOData.Services.WebApi.DtoModels;
using DecouplingOData.Services.WebApi.IoC;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using SimpleInjector;

namespace DecouplingOData.Services.WebApi
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            //container.Options.ResolveUnregisteredConcreteTypes = false;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {   
            // ASP.NET
            services
                .AddControllers(mvcOptions =>  mvcOptions.EnableEndpointRouting = false)
                .AddNewtonsoftJson();;

            // ODATA
            services.AddOData();     

            // SIMPLE INJECTOR
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                       .AddControllerActivation()
                       .AddViewComponentActivation()
                       .AddPageModelActivation();
            });

            var bootStrapper = new BootStrapper();
            bootStrapper.RegisterServices(container);            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // SIMPLE INJECTOR
            app.UseSimpleInjector(container);

            // ASP.NET
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            // ODATA
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
                routeBuilder.EnableDependencyInjection();
            });
            
            // SIMPLE INJECTOR
            container.Verify();
        }
        
        /// <summary>
        /// Simple Injector EDM Model
        /// </summary>
        /// <returns>IEdmModel</returns>
        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();

            odataBuilder.EntitySet<CategoryDtoModel>("CategoriesDtoModels")
                .EntityType
                .HasKey(s => s.Id)
                .Filter(Microsoft.AspNet.OData.Query.QueryOptionSetting.Allowed);
                
            return odataBuilder.GetEdmModel();
        }
    }
}