using System;
using System.Collections.Generic;

namespace UserManager.Api
{
    public partial class Colonne
    {
        public Colonne()
        {
            ProfileColonne = new HashSet<ProfileColonne>();
        }

        public int IdColonne { get; set; }
        public string NomColonne { get; set; }
        public string NomTable { get; set; }
        public string NomDatabase { get; set; }
        public string NomSchema { get; set; }

        public virtual ICollection<ProfileColonne> ProfileColonne { get; set; }
    }
}
