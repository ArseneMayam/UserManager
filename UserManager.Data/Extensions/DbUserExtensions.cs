using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Entities;

namespace UserManager.Data.Extensions
{
    internal static class DbUserExtensions
    {
        public static IList<User> ToModel(this IList<DbUser> list)
        {
            return list.Select(dbUser => dbUser.ToModel()).ToList();
        }
        public static User ToModel(this DbUser dbUser)
        {
            return new User()
            {
                Id = dbUser.Id,
                LastName = dbUser.LastName,
                FirstName = dbUser.FirstName,
                Position = dbUser.Position,
                Address = dbUser.Address
                
            };
        }
    }
}
