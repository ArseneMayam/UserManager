using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
namespace UserManager.Data.Interfaces
{
    public interface IEmployeData
    {
        IList<Employe> getAll();
    }
}
