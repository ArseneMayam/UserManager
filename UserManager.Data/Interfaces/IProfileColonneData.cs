using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;

namespace UserManager.Data.Interfaces
{
   public interface IProfileColonneData
    {
        // recuperer liste des colonne_id d'un profile_id donner
        IQueryable<int> RecupererListeColonneIds(int profile_id);
    }
}
