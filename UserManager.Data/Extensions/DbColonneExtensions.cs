using System;
using System.Collections.Generic;
using System.Linq;
using UserManager.Common.Models;

namespace UserManager.Data.Entities
{
   internal static class DbColonneExtensions
    {
        public static  IList<Colonne> ToModel(this IList<DbColonne> list)
        {
            return list.Select(dbColonne => dbColonne.ToModel()).ToList();
        }

        public static Colonne ToModel(this DbColonne dbColonne)
        {
            return new Colonne()
            {
                ColonneId = dbColonne.ColonneId,
                Nom = dbColonne.Nom
            };
        }
    }
}
