using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Data.Extensions;
using UserManager.Common.Models;
using UserManager.Data.Interfaces;

namespace UserManager.Data
{
    public class UtilisateurData : IUtilisateurData
    {
        internal DataAccessContext DataAccessContext { get; set; }

        public UtilisateurData(IServiceProvider serviceProvider)
        {
            DataAccessContext = serviceProvider.GetService(typeof(DataAccessContext)) as DataAccessContext;
        }
        public Utilisateur RecupererUtilisateur(string username, string password)
        {
            var utilisateur = DataAccessContext.Utilisateur.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            return utilisateur.ToModel();
        }

        public Utilisateur RecupererUtilisateur(string username)
        {
           var utilisateur = DataAccessContext.Utilisateur.Where(u => u.Username == username).FirstOrDefault();
           return utilisateur.ToModel();
        }
    }
}
