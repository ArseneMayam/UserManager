using System;
using System.Collections.Generic;

namespace UserManager.Data.Entities
{
    public partial class DbProfileColonne
    {
        public int ProfileId { get; set; }
        public int ColonneId { get; set; }
        public string Date { get; set; }
    }
}
