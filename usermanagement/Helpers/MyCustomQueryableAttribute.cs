using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Query;
using Microsoft.Extensions.Primitives;

namespace UserManager.Api.Helpers
{
    public class MyCustomQueryableAttribute : EnableQueryAttribute
    {
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            int? pagesize = null;

            if (queryOptions.Request.Query.TryGetValue("pagesize",out StringValues ps))
            {
                pagesize = int.Parse(ps);
            }
            var result = queryOptions.ApplyTo(queryable, new ODataQuerySettings { PageSize = pagesize });
            return result;
        }
    }
}
