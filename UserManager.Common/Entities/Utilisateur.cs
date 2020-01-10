using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManager.Api.Entities
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
    }
}
