using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
        AuthenticationHeaderValue Authorization { get; set; }

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
            var authHeader = HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationToken);
            if (authHeader)
            {
                string stoken = authorizationToken.ToString();
                int length = stoken.Length - 6;
                stoken = stoken.Substring(6, length);
                string base64Encoded = stoken;
                string base64Decoded;
                byte[] data = Convert.FromBase64String(base64Encoded);
                base64Decoded = Encoding.ASCII.GetString(data);
                int separator = base64Decoded.IndexOf(':');
                string userName = base64Decoded.Substring(0, separator);
                EdmModelBuilder.SetUsername(userName);
            }
         

            return ServiceEmploye.List();
        }

    }
}