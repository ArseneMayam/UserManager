using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace UserManager.Api.Helpers
{
    public class BasicAuthenticationHandler : ActionFilterAttribute
    {
        private static StringValues authorizationToken;

        public static string Username
        {
            get
            {

                return authorizationToken;
            }
            set
            {

                authorizationToken = value;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            actionContext.HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationToken);
        }

    }
}
