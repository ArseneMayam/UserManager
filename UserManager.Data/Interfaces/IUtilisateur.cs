using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;

namespace UserManager.Data.Interfaces
{
    interface IUtilisateur
    {
        Utilisateur RecupererUtilisateur(string username, string password);
    }
}
