using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Entities;

namespace UserManager.Data.Extensions
{
    internal static class DbProfileExtensions
    {
        public static IList<Profile> ToModel(this IList<DbProfile> list)
        {
            return list.Select(dbProfile => dbProfile.ToModel()).ToList();
        }

        public static Profile ToModel(this DbProfile dbProfile)
        {
            return new Profile()
            {
                ProfileId = dbProfile.ProfileId,
                Role = dbProfile.Role,
                UtilisateurId = dbProfile.UtilisateurId
            };
        }
    }
}
