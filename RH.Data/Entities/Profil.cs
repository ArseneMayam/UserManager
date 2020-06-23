using System;
using System.Collections.Generic;

namespace UserManager.Api
{
    public partial class Profil
    {
        public Profil()
        {
            ProfileColonne = new HashSet<ProfileColonne>();
            User = new HashSet<User>();
        }

        public int IdProfil { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProfileColonne> ProfileColonne { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
