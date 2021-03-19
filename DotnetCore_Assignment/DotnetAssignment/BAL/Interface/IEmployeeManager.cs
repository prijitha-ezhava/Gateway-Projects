using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IEmployeeManager
    {
        EmployeeViewModel GetEmployee(int? id);
        string AddEmployee(EmployeeViewModel employee);
        string UpdateEmployee(EmployeeViewModel employee);
        string DeleteEmployee(int? id);
        IList<EmployeeViewModel> GetAllemployees();
    }
}
