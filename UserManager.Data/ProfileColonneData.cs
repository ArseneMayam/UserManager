using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Interfaces;

namespace UserManager.Data
{
    public class ProfileColonneData : IProfileColonneData
    {
        internal DataAccessContext DataAccessContext { get; set; }

        public ProfileColonneData(IServiceProvider serviceProvider)
        {
            DataAccessContext = serviceProvider.GetService(typeof(DataAccessContext)) as DataAccessContext;
        }
    
        // recuperer liste des colonne_id d'un profile_id donner
        public IList<int> RecupererListeColonneIds(int profile_id)
        {
            throw new NotImplementedException();
        }

        
    }
}
