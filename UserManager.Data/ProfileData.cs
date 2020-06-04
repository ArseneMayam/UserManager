using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Extensions;
using UserManager.Data.Interfaces;

namespace UserManager.Data
{
    public class ProfileData : IProfileData
    {

        internal DataAccessContext DataAccessContext { get; set; }

        public ProfileData(IServiceProvider serviceProvider)
        {
            DataAccessContext = serviceProvider.GetService(typeof(DataAccessContext)) as DataAccessContext;
        }
        // recuperer un profile avec utilisateur_id
        public Profile RecupererProfile(int utlisateur_id)
        {
           return DataAccessContext.Profile.Single(b => b.Utilisateur_Id == utlisateur_id).ToModel();
        }
    }
}
