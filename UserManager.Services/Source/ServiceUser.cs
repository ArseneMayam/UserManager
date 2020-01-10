using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Api.Entities;
using UserManager.Common.Entities;
using UserManager.Data.Interfaces;
using UserManager.Services.Interfaces;

namespace UserManager.Services.Source
{
    public class ServiceUser : IServiceUser
    {
        internal IUserData UserData { get; set; }
        public ServiceUser(IUserData userData)
        {
            UserData = userData;
        }

        public IQueryable<User> GetUsersList()
        {
            return UserData.GetUsersList().AsQueryable();
        }

        public IEnumerable<User> GetEnumerableUsersList()
        {
            return UserData.GetEnumerableUsersList();
        }

        public IEnumerable<Utilisateur> Utilisateurs()
        {
            return UserData.Utilisateurs();
        }
    }
}
