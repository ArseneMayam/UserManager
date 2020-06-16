using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Query;
using Microsoft.Extensions.Primitives;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNet.OData.Extensions;

namespace UserManager.Api.Helpers
{
    public class MyCustomQueryableAttribute : EnableQueryAttribute
    {
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            int? pagesize = null;

            if (queryOptions.Request.Query.TryGetValue("pagesize", out StringValues ps))
            {
                pagesize = int.Parse(ps);
            }
            var result = queryOptions.ApplyTo(queryable, new ODataQuerySettings { PageSize = pagesize });
            return result;
        }

        public override IEdmModel GetModel(
            Type elementClrType,
            HttpRequest request,
            ActionDescriptor actionDescriptor)
        {

            // Get model for the request
            IEdmModel model = request.GetModel();

            /*if (model == EdmCoreModel.Instance || model.GetEdmType(elementClrType) == null)
            {
                // user has not configured anything or has registered a model without the element type
                // let's create one just for this type and cache it in the action descriptor
                model = actionDescriptor.GetEdmModel(request, elementClrType);
            }

 

            Contract.Assert(model != null);*/
            return model;
        }
    }
}
