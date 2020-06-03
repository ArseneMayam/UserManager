using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data;
namespace UserManager.Services.Interfaces
{
    public interface IDataAccesService
    {
        // Recuperer utilisateur
        Utilisateur RecupererUtilisateur(string username, string password);

        // Recuperer profile de l'utilisateur
        Profile RecupererProfile(int utlisateur_id);

        // Recuperer la liste des colonne_id avec un profile_id
        IList<int> RecupererListeColonneIds(int profile_id);

        // Recuperer tous les colonnes avec la liste des colonnes_id
        // pour gerer les acces aux propriétés de Employé
        IList<Colonne> RecupererColonnes(IList<int> colonne_id);

    }
}
