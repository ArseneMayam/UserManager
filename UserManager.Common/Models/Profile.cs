using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManager.Common.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string Role { get; set; }
        public int UtilisateurId { get; set; }
    }
}
