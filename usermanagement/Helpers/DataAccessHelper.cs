using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;

namespace UserManager.Api.Helpers
{
    public class DataAccessHelper
    {
        public static IDataAccesService DataAccesService { get; private set; }
        public static void InitDataAccessService(IDataAccesService dataAccesService)
        {
            DataAccesService = dataAccesService;
        }

        public static IQueryable<Colonne> GetColonnes(string username)
        {
            return DataAccesService.GererDataAccess(username);
        }

    }
}
