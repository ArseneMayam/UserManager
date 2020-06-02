using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}