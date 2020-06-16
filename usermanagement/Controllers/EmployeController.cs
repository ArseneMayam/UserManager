using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.OData.Edm;
using UserManager.Api.Helpers;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;
using UserManager.Services.Source;

namespace UserManager.Api.Controllers
{
    [Produces("application/json; odata.metadata=none")]
    public class EmployeController : ODataController
    {
        private StringValues authorizationToken;

        internal IEmployeService ServiceEmploye { get; set; }
        internal IDataAccesService DataAccessService { get; set; }
      
        public EmployeController(IEmployeService serviceEmploye, IDataAccesService dataAccessService)
        {

            ServiceEmploye = serviceEmploye;
            DataAccessService = dataAccessService;
        }
        
     
        [HttpGet]
        [ODataRoute("", RouteName = "Employe")]
        [MyCustomQueryable()]
        [BasicAuthenticationHandler()]
        public IQueryable<Employe> Get()
        {
            IEdmModel model = this.Request.GetModel();
            
            var empl = model.EntityContainer.FindEntitySet("employes");
            var e = model.EntityContainer.FindEntitySet("employes") as EdmEntitySet;
          
            return ServiceEmploye.List();
        }

    }
}