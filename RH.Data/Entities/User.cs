using System;
using System.Collections.Generic;

namespace UserManager.Api
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Description { get; set; }
        public int IdProfil { get; set; }
        public string NomUser { get; set; }

        public virtual Profil IdProfilNavigation { get; set; }
    }
}
