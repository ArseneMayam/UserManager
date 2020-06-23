using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Common.Models;

namespace UserManager.Api.Helpers
{
    public class MyActionFilter : EnableQueryAttribute, IActionFilter 
    {


       /* public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }*/
      /*  public override IEdmModel GetModel(
         Type elementClrType,
         HttpRequest request,
         ActionDescriptor actionDescriptor)
        {
            string username = request.HttpContext.User.Identity.Name;
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var employes = builder.EntitySet<Employe>("employes");
            // Get model for the request
            // IEdmModel model = request.GetModel();
           IQueryable<Colonne> colonnes = DataAccesService.GererDataAccess("amayam");
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

        }*/
    }
}
