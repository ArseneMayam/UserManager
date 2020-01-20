using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Api.Entities;
using UserManager.Common.Entities;
using UserManager.Framework.Pipeline;
using UserManager.Services.Interfaces;

namespace WebApplication3.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        internal IServiceUser ServiceUser { get; set; }
        internal IUserManagerServicePipeline Pipeline { get; set; }
        public UserController(IServiceUser serviceUser, IUserManagerServicePipeline pipeline)
        {
            ServiceUser = serviceUser;
            Pipeline = pipeline;
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
            var cacheKey = "userdata";
            var fromCache = Pipeline.TestRetrieveDataCache(cacheKey);
            if(fromCache != null)
            {
                return fromCache as IEnumerable<Utilisateur>;
            }
            var result = ServiceUser.Utilisateurs();
            Pipeline.TestStoreDataCache(cacheKey, result);
            return result;
        }
    }
}
