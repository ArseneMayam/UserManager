using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Interfaces;
using UserManager.Data;
using Microsoft.EntityFrameworkCore;
using UserManager.Data.Extensions;
using System.Linq;

namespace UserManager.Data
{
    public class EmployeData : IEmployeData
    {
        internal DataAccessContext DataAccessContext { get; set; }

        public EmployeData(IServiceProvider serviceProvider)
        {
            DataAccessContext = serviceProvider.GetService(typeof(DataAccessContext)) as DataAccessContext;
        }
  
        public IList<Employe> list()
        {
            var list = DataAccessContext.Employe.ToListAsync();
            list.Wait();
            return list.Result.ToModel();
        }
    }
}
