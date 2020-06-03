using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using UserManager.Framework.Pipeline;
using UserManager.Data.Interfaces;
using UserManager.Common.Models;

namespace usermanagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddDbContext<UserManager.Data.DataAccessContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RhbdConnectionStrings"), providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddScoped<IEmployeData,UserManager.Data.EmployeData> ();
            services.AddScoped<UserManager.Services.Interfaces.IEmployeService, UserManager.Services.Source.EmployeService>();

            services.AddScoped<IUserManagerServicePipeline, UserManagerServicePipeline>();
            services.AddMvcCore(action => action.EnableEndpointRouting = false);
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Expand().Select().Count().OrderBy().Filter().MaxTop(null);
                routeBuilder.MapODataServiceRoute("v1", "v1", GetEdmModel());
            });


        }

        // pour que le count fonctionne faire un mapping oData sur le modele
        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Employe>("employes");
            // ignore the list of properties to exclude
             var employes = builder.EntitySet<Employe>("employes");
             employes.EntityType.Ignore(emp => emp.Nas);

            return builder.GetEdmModel();
        }
    }
}
