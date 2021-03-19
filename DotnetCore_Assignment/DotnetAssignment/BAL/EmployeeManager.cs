using BAL.Interface;
using BusinessEntities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //To Add new employee record 
        public string AddEmployee(EmployeeViewModel employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }


        //To Delete the record on a particular employee 
        public string DeleteEmployee(int? id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        //To View all employees details 
        public IList<EmployeeViewModel> GetAllemployees()
        {
            return _employeeRepository.GetAllemployees();
        }


        //Get the details of a particular employee
        public EmployeeViewModel GetEmployee(int? id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        //To Update the records of a particular employee 
        public string UpdateEmployee(EmployeeViewModel employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }
    }
}
