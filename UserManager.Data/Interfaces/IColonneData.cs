using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
namespace UserManager.Data.Interfaces
{
    public interface IColonneData
    {
        // recuperer les colonnes avec une liste de colonne_id
        IList<Colonne> RecupererColonnes(IQueryable<int> colonne_id);
        // tests purpose
        IList<Colonne> List();
    }
}
