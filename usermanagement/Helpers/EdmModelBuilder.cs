using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;
using UserManager.Services.Source;

namespace UserManager.Api.Helpers
{
    public static class EdmModelBuilder
    {
             

        public static IEdmModel GetEdmModelEmployes(IDataAccesService dataAccesService)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var employes = builder.EntitySet<Employe>("employes");
            // ignore the list of properties to exclude    
            /// pour recuperer les colonnes   
            string username = DecodeBase64(BasicAuthenticationHandler.Username);
           // IQueryable<Colonne> colonnes = dataAccesService.GererDataAccess("amayam", "abcd");
            IQueryable<Colonne> colonnes = dataAccesService.GererDataAccess("amayam");


            foreach (Colonne col in colonnes)
            {               

                switch (col.Nom.ToString().Trim())
                {

                    case "matricule":
                        employes.EntityType.Ignore(e => e.Matricule);
                        break;
                    case "Code_Empl":
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

    
        public static string DecodeBase64(string decodeUser)
        {
            if (String.IsNullOrEmpty(decodeUser))
            {
                return null;
            }
            var header = decodeUser.Replace("Basic", "").Trim();
            var base64EncodedBytes = Convert.FromBase64String(header);
            var cred = Encoding.UTF8.GetString(base64EncodedBytes).Split(new[] { ':' }, 2);
            var username = cred[0];
            return username;

        }


    }
}
