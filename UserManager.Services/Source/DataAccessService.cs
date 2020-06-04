using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data;
using UserManager.Data.Interfaces;
using UserManager.Services.Interfaces;
namespace UserManager.Services.Source
{
    public class DataAccessService : IDataAccesService
    {
        internal IProfileData ProfileData { get; set; }
        internal IUtilisateurData UtilisateurData { get; set; }
        internal IColonneData ColonneData { get; set; }
        internal IProfileColonneData ProfileColonneData { get; set; } 
        public DataAccessService(IProfileData profileData, IUtilisateurData utilisateurData, IColonneData colonneData, IProfileColonneData profileColonneData)
        {
            ProfileData = profileData;
            UtilisateurData = utilisateurData;
            ColonneData = colonneData;
            ProfileColonneData = profileColonneData;

        }
        // Methodes pour gerer data access 
        // Avec credentials
        public IQueryable<Colonne> GererDataAccess(string username, string password)
        {
            // recuperer utilisateur
            Utilisateur utilisateur = RecupererUtilisateur(username, password);

            //recuperer profile utilisateur
            Profile profile = RecupererProfile(utilisateur.UtilisateurId);

            // Recuperer liste colonne Ids
            IQueryable<int> listeColonneIds = RecupererListeColonneIds(profile.ProfileId);

            // recuperer et retourner les colonnes
            IQueryable<Colonne> colonnes = RecupererColonnes(listeColonneIds);
            return colonnes;
        }
        // sans params pour tests
        public IQueryable<Colonne> GererDataAccess(int utilisateur_id)
        {
            //recuperer profile utilisateur
            Profile profile = RecupererProfile(utilisateur_id);

            // Recuperer liste colonne Ids : ProfileColonne
            IQueryable<int> listeColonneIds = RecupererListeColonneIds(profile.ProfileId);

            // recuperer et retourner les colonnes
            IQueryable<Colonne> colonnes = RecupererColonnes(listeColonneIds);
            return colonnes;
        }

        // Recuperer tous les colonnes avec la liste des colonnes_id       
        public IQueryable<Colonne> RecupererColonnes(IQueryable<int> listeColonne_id)
        {
            return ColonneData.RecupererColonnes(listeColonne_id).AsQueryable();
        }
        // Recuperer la liste des colonne_id avec un profile_id
        public IQueryable<int> RecupererListeColonneIds(int profile_id)
        {
            return ProfileColonneData.RecupererListeColonneIds(profile_id);
        }
        // Recuperer profile de l'utilisateur     
        public Profile RecupererProfile(int utlisateur_id)
        {
            return ProfileData.RecupererProfile(utlisateur_id);
        }
        // Recuperer utilisateur
        public Utilisateur RecupererUtilisateur(string username, string password)
        {
            return UtilisateurData.RecupererUtilisateur(username,password);
        }
    }
}
