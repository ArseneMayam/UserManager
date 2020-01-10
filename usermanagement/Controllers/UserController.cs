using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Api.Entities;
using UserManager.Common.Entities;
using UserManager.Services.Interfaces;

namespace WebApplication3.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        internal IServiceUser ServiceUser { get; set; }

        public UserController(IServiceUser serviceUser)
        {
            ServiceUser = serviceUser;
        }
        //// GET api/users
        [HttpGet]
        public IQueryable<User> Get()
        {

            return ServiceUser.GetUsersList();
        }
        [HttpGet("/list")]
        public IEnumerable<User> GetEnumerableList()
        {

            return ServiceUser.GetEnumerableUsersList();
        }

        [HttpGet("/utilisateurs")]
        public IEnumerable<Utilisateur> Utilisateurs()
        {

            return ServiceUser.Utilisateurs();
        }
    }
}
