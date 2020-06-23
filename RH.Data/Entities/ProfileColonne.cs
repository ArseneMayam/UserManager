using System;
using System.Collections.Generic;

namespace UserManager.Api
{
    public partial class ProfileColonne
    {
        public int IdProfilColonne { get; set; }
        public int IdProfil { get; set; }
        public int IdColonne { get; set; }

        public virtual Colonne IdColonneNavigation { get; set; }
        public virtual Profil IdProfilNavigation { get; set; }
    }
}
