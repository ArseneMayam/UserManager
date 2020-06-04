using System;
using System.Collections.Generic;
using System.Linq;
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

        // Recuperer la liste des colonne_id avec un profile_id : ProfileColonne
        IList<int> RecupererListeColonneIds(int profile_id);

        // Recuperer tous les colonnes avec la liste des colonnes_id       
        IQueryable<Colonne> RecupererColonnes(IList<int> colonne_id);

        // Methodes pour gerer data access 
        // Avec credentials
        IQueryable<Colonne> GererDataAccess(string username, string password);
        // sans params pour tests
        IQueryable<Colonne> GererDataAccess(int utilisateur_id);

    }
}
