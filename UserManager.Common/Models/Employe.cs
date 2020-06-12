using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace UserManager.Common.Models
{
    public class Employe
    {
        [Key]
        public int Employe_Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Code_Empl { get; set; }
        public string Matricule { get; set; }
        public string Rib { get; set; }
        public int Nas { get; set; }
        public string Tin { get; set; }
        public string Nationalite { get; set; }

        public Expression GetPropertyKey(string name)
        {
            return Expression.Constant(name);
        }
    }
}
