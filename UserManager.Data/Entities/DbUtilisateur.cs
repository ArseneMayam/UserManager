using System;
using System.Collections.Generic;

namespace UserManager.Data.Entities
{
    public partial class DbUtilisateur
    {
        public int Utilisateur_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
