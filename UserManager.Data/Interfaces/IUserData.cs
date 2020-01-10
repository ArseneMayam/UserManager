using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Api.Entities;
using UserManager.Common.Entities;

namespace UserManager.Data.Interfaces
{
    public interface IUserData
    {
        IList<User> GetUsersList();
        IEnumerable<User> GetEnumerableUsersList();

        IEnumerable<Utilisateur> Utilisateurs();
    }
}
