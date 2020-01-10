using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using UserManager.Data;
using UserManager.Data.Interfaces;
using UserManager.Services.Interfaces;
using UserManager.Services.Source;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using UserManager.Common.Entities;

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
            services.AddDbContext<UserDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserManagementConnectionStrings"), providerOptions => providerOptions.EnableRetryOnFailure()));
            services.AddDbContext<UtilisateurDataContext>(options => options.UseSqlServer("Server=CA-L1B00SQ2;Database=usermanagement;Trusted_Connection=True;", providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IServiceUser, ServiceUser>();
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
           /* else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();*/


            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Expand().Select().Count().OrderBy().Filter().MaxTop(null);
                routeBuilder.MapODataServiceRoute("api", "api", GetEdmModel());
            });
            /*  app.Run(async (context) =>
              {
                  await context.Response.WriteAsync("Hello World!");
              });
              */

        }

        // pour que le count fonctionne faire un mapping oData sur le modele
        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<User>("Users");
            return builder.GetEdmModel();
        }
    }
}
