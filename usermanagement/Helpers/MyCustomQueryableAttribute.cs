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
using Microsoft.AspNet.OData.Builder;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;

namespace UserManager.Api.Helpers
{
    public class MyCustomQueryableAttribute : EnableQueryAttribute
    {
   
        public MyCustomQueryableAttribute()
        {

        }
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

    }
}
