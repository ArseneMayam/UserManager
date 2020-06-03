using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;

namespace UserManager.Data.Interfaces
{
    public interface IProfileData
    {
        // recuperer un profile avec utilisateur_id
        Profile RecupererProfile(int utlisateur_id);
    }
}
