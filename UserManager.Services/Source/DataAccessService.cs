using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data;
using UserManager.Services.Interfaces;
namespace UserManager.Services.Source
{
    public class DataAccessService : IDataAccesService
    {
        // Methodes pour gerer data access 
        // Avec credentials
        public IList<Colonne> GererDataAccess(string username, string password)
        {
            throw new NotImplementedException();
        }
        // sans params pour tests
        public IList<Colonne> GererDataAccess()
        {
            throw new NotImplementedException();
        }

        // Recuperer tous les colonnes avec la liste des colonnes_id       
        public IList<Colonne> RecupererColonnes(IList<int> colonne_id)
        {
            throw new NotImplementedException();
        }
        // Recuperer la liste des colonne_id avec un profile_id
        public IList<int> RecupererListeColonneIds(int profile_id)
        {
            throw new NotImplementedException();
        }
        // Recuperer profile de l'utilisateur     
        public Profile RecupererProfile(int utlisateur_id)
        {
            throw new NotImplementedException();
        }
        // Recuperer utilisateur
        public Utilisateur RecupererUtilisateur(string username, string password)
        {
            return null;
        }
    }
}
