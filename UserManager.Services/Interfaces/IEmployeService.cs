using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UserManager.Common.Models;

namespace UserManager.Services.Interfaces
{
    public interface IEmployeService
    {
        IQueryable<Employe> getAll();
        IQueryable<Employe> getAllMock();
    }
}
