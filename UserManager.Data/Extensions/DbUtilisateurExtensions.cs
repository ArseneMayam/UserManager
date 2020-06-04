using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
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
                UtilisateurId = dbUtilisateur.Utilisateur_Id,
                Username = dbUtilisateur.Username,
                Password = dbUtilisateur.Password
            };
        }
    }
}
