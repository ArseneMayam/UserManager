using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;

namespace UserManager.Data.Interfaces
{
    interface IProfileData
    {
        Profile RecupererProfile(int utlisateur_id);
    }
}
