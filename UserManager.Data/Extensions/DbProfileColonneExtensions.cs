using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Entities;
namespace UserManager.Data.Extensions
{
    internal static class DbProfileColonneExtensions
    {
        public static IList<ProfileColonne> ToModel(this IList<DbProfileColonne> list)
        {
            return list.Select(dbProfile => dbProfile.ToModel()).ToList();
        }

        public static ProfileColonne ToModel(this DbProfileColonne dbProfileColonne)
        {
            return new ProfileColonne()
            {
                ColonneId = dbProfileColonne.Colonne_Id,
                Date = dbProfileColonne.Date,
                ProfileId = dbProfileColonne.Profile_Id
            };
        }
    }
}
