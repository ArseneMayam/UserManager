using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;
using UserManager.Services.Source;

namespace UserManager.Api.Helpers
{
    public static class EdmModelBuilder
    {
        private static string Username { get; set; }

        public static IEdmModel GetEdmModelEmployes(IDataAccesService dataAccesService)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var employes = builder.EntitySet<Employe>("employes");
            // ignore the list of properties to exclude    
            /// pour recuperer les colonnes   

            IQueryable<Colonne> colonnes = dataAccesService.GererDataAccess("amayam", "abcd");
            Type myType = typeof(Employe);
            foreach (Colonne col in colonnes)
            {
                string PropertyToIgnore = col.Nom;

                switch (PropertyToIgnore)
                {
                    case "matricule":
                        employes.EntityType.Ignore(e => e.Matricule);
                        break;
                    case "code_empl":
                        employes.EntityType.Ignore(e => e.Code_Empl);
                        break;
                    case "rib":
                        employes.EntityType.Ignore(e => e.Rib);
                        break;
                    case "nas":
                        employes.EntityType.Ignore(e => e.Nas);
                        break;
                    case "tin":
                        employes.EntityType.Ignore(e => e.Tin);
                        break;

                }


            }


            return builder.GetEdmModel();
        }

        public static void SetUsername(string username)
        {
            Username = username;
        }


    }
}
