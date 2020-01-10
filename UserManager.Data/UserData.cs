using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Api.Entities;
using UserManager.Common.Entities;
using UserManager.Data.Extensions;
using UserManager.Data.Interfaces;

namespace UserManager.Data
{
    public class UserData : IUserData
    {
        internal UserDataContext DataContext { get; set; }
        internal UtilisateurDataContext UtilisateurDataContext { get; set; }
        public UserData(IServiceProvider provider)
        {
            DataContext = provider.GetService(typeof(UserDataContext)) as UserDataContext;
            UtilisateurDataContext = provider.GetService(typeof(UtilisateurDataContext)) as UtilisateurDataContext;
        }
        /// <summary>
        ///  Use of sqlQuery
        /// </summary>
        /// <returns>List of users</returns>
        public IList<User> GetUsersList()
        {
            /*  var listTask = DataContext.Users.FromSql(@"SELECT * FROM dbo.utilisateur").ToListAsync();           

              listTask.Wait();

              return listTask.Result.ToModel();*/
            return null;
        }

        // returns IEnumerable
        public IEnumerable<User> GetEnumerableUsersList()
        {
            var list = DataContext.Users.OrderBy(u => u.LastName).ToList();

            return list.ToModel();
        }

        public IEnumerable<Utilisateur> Utilisateurs()
        {
            var list = UtilisateurDataContext.Utilisateurs.ToList();

            return list.ToModel();
        }
    }
}
