using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Interfaces;
using UserManager.Data;
using Microsoft.EntityFrameworkCore;
using UserManager.Data.Extensions;

namespace UserManager.Data
{
    public class EmployeData : IEmployeData
    {
        internal DataAccessContext DataAccessContext { get; set; }

        public EmployeData(IServiceProvider serviceProvider)
        {
            DataAccessContext = serviceProvider.GetService(typeof(DataAccessContext)) as DataAccessContext;
        }
        public IList<Employe> getAll()
        {
            var list = DataAccessContext.Employe.FromSql(@"Select
                                                            EmployeId,
                                                            Nom,
                                                            Prenom,
                                                            CodeEmpl,
                                                            Matricule,
                                                            Rib,
                                                            Nas,
                                                            Tin,
                                                            Natioanlite
                                                          FROM
                                                            employe
                                                        ").ToListAsync();
            list.Wait();
            return list.Result.ToModel();
        }
    }
}
