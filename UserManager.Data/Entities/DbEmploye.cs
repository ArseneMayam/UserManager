using System;
using System.Collections.Generic;

namespace UserManager.Data.Entities
{
    public partial class DbEmploye
    {
        public int EmployeId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int CodeEmpl { get; set; }
        public string Matricule { get; set; }
        public string Rib { get; set; }
        public int Nas { get; set; }
        public string Tin { get; set; }
        public string Natioanlite { get; set; }
    }
}
