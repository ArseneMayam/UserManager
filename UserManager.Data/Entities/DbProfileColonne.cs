using System;
using System.Collections.Generic;

namespace UserManager.Data.Entities
{
    public partial class DbProfileColonne
    {
        public int Profile_Id { get; set; }
        public int Colonne_Id { get; set; }
        public string Date { get; set; }
    }
}
