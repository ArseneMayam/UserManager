using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;

namespace UserManager.Data.Interfaces
{
    interface IProfileColonneData
    {
        // recuperer liste des colonne_id d'un profile_id donner
        IList<int> RecupererListeColonneIds(int profile_id);
    }
}
