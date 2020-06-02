using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManager.Common.Models
{
   public class ProfileColonne
    {
        [Key]
        public int ProfileId { get; set; }
        public int ColonneId { get; set; }
        public string Date { get; set; }
    }
}
