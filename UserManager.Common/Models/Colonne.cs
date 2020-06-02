using System.ComponentModel.DataAnnotations;

namespace UserManager.Common.Models
{
    public class Colonne
    {
        [Key]
        public int ColonneId { get; set; }
        public string Nom { get; set; }
    }
}
