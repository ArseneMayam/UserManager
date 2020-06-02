using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.Common.Models;

namespace UserManager.Api.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

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
    }
}