using System.ComponentModel.DataAnnotations;

namespace UserManager.Common.Models
{
    public class Utilisateur
    {
        [Key]
        public int UtilisateurId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
