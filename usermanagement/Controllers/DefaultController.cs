using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;
using UserManager.Services.Source;

namespace UserManager.Api.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        internal IEmployeService ServiceEmploye { get; set; }
        internal IDataAccesService DataAccessService { get; set; }

        public DefaultController(IEmployeService serviceEmploye, IDataAccesService dataAccessService)
        {

            ServiceEmploye = serviceEmploye;
            DataAccessService = dataAccessService;
        }


        [HttpGet]
        [Route("version")]
        public ActionResult<string> Version()
        {
            return "Version 1.0.0 !!!!";
        }

        [HttpGet]
        [Route("employe")]
        public ActionResult<Employe> Employe()
        {
            return new Employe()
            {
                CodeEmpl = 123,
                EmployeId = 01,
                Matricule = "LT46",
                Nas = 946,
                Nationalite = "Canada",
                Nom = "Dennis",
                Prenom = "Lemaire",
                Rib = "LAS976",
                Tin = "SA9"
            };
        }

        [HttpGet]
        [Route("employes")]
        public IQueryable Employes()
        {
            return ServiceEmploye.List();
        }

        [HttpGet]
        [Route("colonnes")]
        public IQueryable Colonnes()
        {
            IList<int> list = new List<int>() {1,2,3,7};
            return DataAccessService.RecupererColonnes(list);
        }
    }
}