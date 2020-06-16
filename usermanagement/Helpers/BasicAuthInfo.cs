using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManager.Api.Helpers
{
    public static class BasicAuthInfo
    {
        public static string UserName { get; set; }

        internal static void SetUsername(string userName)
        {
            UserName = userName;
        }

        internal static string GetUsername()
        {
            return UserName;
        }
    }
}
