using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Api.Entities;
using UserManager.Data.Entities;

namespace UserManager.Data.Extensions
{
    internal static class DbUtilisateurExtensions
    {
        public static IList<Utilisateur> ToModel(this IList<DbUtilisateur> list)
        {
            return list.Select(dbUtilisateur => dbUtilisateur.ToModel()).ToList();
        }

        public static Utilisateur ToModel(this DbUtilisateur dbUtilisateur)
        {
            return new Utilisateur()
            {
                Id = dbUtilisateur.Id,
                LastName = dbUtilisateur.LastName,
                FirstName = dbUtilisateur.FirstName,
                Position = dbUtilisateur.Position,
                Address = dbUtilisateur.Address

            };
        }
    }
}
