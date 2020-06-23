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
using UserManager.Api.Helpers;
using UserManager.Services.Interfaces;

namespace usermanagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IDataAccesService DataAccesService { get; set; }
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
            services.AddScoped<IColonneData, UserManager.Data.ColonneData>();
            services.AddScoped<IProfileData, UserManager.Data.ProfileData>();
            services.AddScoped<IProfileColonneData, UserManager.Data.ProfileColonneData>();
            services.AddScoped<IUtilisateurData, UserManager.Data.UtilisateurData>();

            services.AddScoped<IEmployeService, UserManager.Services.Source.EmployeService>();
            services.AddScoped<IDataAccesService, UserManager.Services.Source.DataAccessService>();

            services.AddScoped<IUserManagerServicePipeline, UserManagerServicePipeline>();
            services.AddScoped<MyCustomQueryableAttribute>();
            services.AddScoped<MyActionFilter>();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDataAccesService dataAccesService)
        {
            DataAccesService = dataAccesService;
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
               
                // routeBuilder : ajouté les methodes de Odata et buildé le url de l API 
                routeBuilder.Expand().Select().Count().OrderBy().Filter().MaxTop(null);          
                routeBuilder.MapODataServiceRoute("Employe", "odata/v1/employes", EdmModelBuilder.GetEdmModelEmployes());
            });


        }

        // pour que le count fonctionne faire un mapping oData sur le modele
       private IEdmModel GetEdmModelEmployes(IDataAccesService dataAccesService=null)
         {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var employes = builder.EntitySet<Employe>("employes");
            var sets = builder.EntitySets;
            // ignore the list of properties to exclude    
            /// appeler service pour recuperer les colonnes       
            /// 
            //IQueryable<Colonne> colonnes = dataAccesService.GererDataAccess(1);
            // employes.EntityType.Ignore(e => e.Nas);
            return builder.GetEdmModel();
        }

    }
}
