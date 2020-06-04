using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }
    }
}
