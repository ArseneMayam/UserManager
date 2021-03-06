﻿using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;

namespace UserManager.Data.Interfaces
{
    public interface IUtilisateurData
    {
        Utilisateur RecupererUtilisateur(string username, string password);
        Utilisateur RecupererUtilisateur(string username);
    }
}
