using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;

namespace UserManager.Data.Interfaces
{
    interface IProfileColonne
    {
        IList<ProfileColonne> RecupererListeProfileColonne();
    }
}
