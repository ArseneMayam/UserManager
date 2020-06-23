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
              
        public static IEdmModel GetEdmModelEmployes(IQueryable<Colonne> colonnes = null)
        {

            var Builder = new ODataConventionModelBuilder();
            var Employe = Builder.EntitySet<Employe>("employes");
            if (colonnes != null)
            {
                foreach (Colonne col in colonnes)
                {
                    switch (col.Nom.ToString().Trim())
                    {

                        case "matricule":
                            Employe.EntityType.Ignore(e => e.Matricule);
                            break;
                        case "code_empl":
                            Employe.EntityType.Ignore(e => e.Code_Empl);
                            break;
                        case "rib":
                            Employe.EntityType.Ignore(e => e.Rib);
                            break;
                        case "nas":
                            Employe.EntityType.Ignore(e => e.Nas);
                           
                            break;
                        case "tin":
                            Employe.EntityType.Ignore(e => e.Tin);
                            break;
                    }
                }               
                
            }
            
            return Builder.GetEdmModel();

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
