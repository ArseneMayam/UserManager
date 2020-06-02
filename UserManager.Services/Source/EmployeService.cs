using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data;
using UserManager.Data.Interfaces;
using UserManager.Services.Interfaces;
namespace UserManager.Services.Source
{
    public class EmployeService : IEmployeService
    {
        internal IEmployeData EmployeData { get; set; }
        public EmployeService(IEmployeData employeData)
        {
            EmployeData = employeData;
        }
        public IQueryable<Employe> getAll()
        {
            return EmployeData.getAll().AsQueryable();
        }
    }
}
