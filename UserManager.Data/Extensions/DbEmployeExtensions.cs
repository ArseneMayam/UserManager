using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Entities;

namespace UserManager.Data.Extensions
{
    internal static class DbEmployeExtensions
    {
        public static IList<Employe> ToModel(this IList<DbEmploye> list)
        {
            return list.Select(dbEmploye => dbEmploye.ToModel()).ToList();
        }
        
        public static Employe ToModel(this DbEmploye dbEmploye)
        {
            return new Employe()
            {
                EmployeId = dbEmploye.EmployeId,
                CodeEmpl = dbEmploye.CodeEmpl,
                Matricule = dbEmploye.Matricule,
                Nas = dbEmploye.Nas,
                Nationalite = dbEmploye.Natioanlite,
                Nom = dbEmploye.Nom,
                Prenom = dbEmploye.Prenom,
                Rib = dbEmploye.Rib,
                Tin = dbEmploye.Tin                    
                
            };
        }
    }
}
