using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UserManagerCacheAttribute : UserManagerAttribute
    {

        public string NomCache { get; set; }
        //create properties similar to ResponseCache

        // constructeur 
        public UserManagerCacheAttribute() { }

        // Duration :
        // Get ou set la durée en secondes pour lequel la reponse est mise en cache
        // Ceci assgine "max-age" dans "Cache-control" header
        public int Duration { get; set; }
        // CacheProfileName
        // Get ou set la valeur de cache profile name
        public string CacheProfileName { get; set; }

        //
        public int Order { get; set; }
    }
}
