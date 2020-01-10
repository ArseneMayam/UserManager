using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Api.Entities;
using UserManager.Common.Entities;

namespace UserManager.Services.Interfaces
{
    public interface IServiceUser
    {
        IQueryable<User> GetUsersList();
        IEnumerable<User> GetEnumerableUsersList();
        IEnumerable<Utilisateur> Utilisateurs();
    }
}
