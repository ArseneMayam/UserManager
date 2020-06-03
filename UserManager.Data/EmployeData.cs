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
            var list = DataAccessContext.Employe.FromSql(@"SELECT
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


        public  IList<Employe> getAllMock()
        {
            IList<Employe> list = new List<Employe>
            {
                new Employe() { EmployeId = 1, CodeEmpl = 180, Matricule = "ad14", Nas = 5778, Nationalite = "kenya", Nom = "Nina", Prenom = "Ayoi", Rib = "24f", Tin = "44ef" },
                new Employe() { EmployeId = 2, CodeEmpl = 154, Matricule = "hr67", Nas = 464568, Nationalite = "canada", Nom = "carol", Prenom = "erwi", Rib = "ha6", Tin = "hrt3" },
                new Employe() { EmployeId = 3, CodeEmpl = 124, Matricule = "shik7", Nas = 0561, Nationalite = "france", Nom = "marie", Prenom = "siyi", Rib = "nb5", Tin = "6hd" },
                new Employe() { EmployeId = 4, CodeEmpl = 157, Matricule = "lofy6", Nas = 7269, Nationalite = "belgium", Nom = "tony", Prenom = "frac", Rib = "gtt5", Tin = "hrh4" }
            };
            return list;
        }
    }
}
