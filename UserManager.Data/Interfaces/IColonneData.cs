using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
namespace UserManager.Data.Interfaces
{
    interface IColonneData
    {
        IList<Colonne> RecupererListeColonnes();
        Colonne RecupererColonneId(int id);
    }
}
