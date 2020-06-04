using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.Api.Helpers;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;
using UserManager.Services.Source;

namespace UserManager.Api.Controllers
{
    [Produces("application/json; odata.metadata=none")]
    public class EmployeController : ODataController
    {
        internal IEmployeService ServiceEmploye { get; set; }
        internal IDataAccesService DataAccessService { get; set; }

        public EmployeController(IEmployeService serviceEmploye, IDataAccesService dataAccessService)
        {

            ServiceEmploye = serviceEmploye;
            DataAccessService = dataAccessService;
        }
        
     
        [HttpGet]
        [ODataRoute("", RouteName = "Employe")]
        [EnableQuery()]
        public IQueryable<Employe> Get()
        {
            return ServiceEmploye.List();
        }

    }
}