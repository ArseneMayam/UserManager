using System;
using System.Collections.Generic;

namespace UserManager.Data.Entities
{
    public partial class DbProfile
    {
        public int Profile_Id { get; set; }
        public string Role { get; set; }
        public int Utilisateur_Id { get; set; }
    }
}
