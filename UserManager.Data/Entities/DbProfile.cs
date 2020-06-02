using System;
using System.Collections.Generic;

namespace UserManager.Data.Entities
{
    public partial class DbProfile
    {
        public int ProfileId { get; set; }
        public string Role { get; set; }
        public int UtilisateurId { get; set; }
    }
}
