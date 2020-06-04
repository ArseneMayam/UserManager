﻿using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
namespace UserManager.Data.Interfaces
{
    public interface IColonneData
    {
        // recuperer les colonnes avec une liste de colonne_id
        IList<Colonne> RecupererColonnes(IList<int> colonne_id);
        // tests purpose
        IList<Colonne> List();
    }
}
