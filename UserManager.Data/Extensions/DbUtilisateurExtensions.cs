using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Entities;

namespace UserManager.Data.Extensions
{
    internal static class DbUtilisateurExtensions
    {
        
        public static IList<Utilisateur> ToModel(this IList<DbUtilisateur> list)
        {
            return null;
        }

        public static Utilisateur ToModel(this DbUtilisateur dbUtilisateur)
        {
            return new Utilisateur()
            {
                UtilisateurId = dbUtilisateur.UtilisateurId,
                Username = dbUtilisateur.Username,
                Password = dbUtilisateur.Password
            };
        }
    }
}
