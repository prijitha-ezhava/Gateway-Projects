using BusinessEntities;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;


namespace DAL.Repository
{
    public class EmployeeRepo : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Add new employee record 
        public string AddEmployee(EmployeeViewModel employee)
        {
            if (employee != null)
            {
                EmployeesData employees = new EmployeesData();
                employees.Name = employee.Name;
                employees.Department = employee.Department;
                employees.Salary = employee.Salary;
                employees.IsManager = employee.IsManager;
                employees.Manager = employee.Manager;
                employees.Phone = employee.Phone;
                employees.Email = employee.Email;
                _dbContext.Add(employees);
                _dbContext.SaveChanges();
                return "Students added successfully!!!";

            }
            return "Model is null!";
        }

        //To Delete the record on a particular employee 
        public string DeleteEmployee(int? id)
        {
            EmployeesData employees = _dbContext.EmployeesData.Find(id);
            _dbContext.EmployeesData.Remove(employees);
            _dbContext.SaveChanges();
            return "Deleted Successfully!!";
        }

        //To View all employees details 
        public IList<EmployeeViewModel> GetAllemployees()
        {
            IList<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            var result = _dbContext.EmployeesData.ToList();

            for (int i = 0; i < result.Count; i++)
            {
                EmployeeViewModel employee = new EmployeeViewModel();
                employee.ID = result[i].ID;
                employee.Name = result[i].Name;
                employee.Department = result[i].Department;
                employee.Salary = result[i].Salary;
                employee.IsManager = result[i].IsManager;
                employee.Manager = result[i].Manager;
                employee.Phone = result[i].Phone;
                employee.Email = result[i].Email;
                employeesList.Add(employee);
            }
            return employeesList;
        }

        //Get the details of a particular employee
        public EmployeeViewModel GetEmployee(int? id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            EmployeesData entity = _dbContext.EmployeesData.Find(id);
            employee.ID = entity.ID;
            employee.Name = entity.Name;
            employee.Department = entity.Department;
            employee.Salary = entity.Salary;
            employee.IsManager = entity.IsManager;
            employee.Manager = entity.Manager;
            employee.Phone = entity.Phone;
            employee.Email = entity.Email;
            return employee;
        }


        //To Update the records of a particular employee 
        public string UpdateEmployee(EmployeeViewModel employee)
        {
            if (employee != null)
            {

                EmployeesData entity = _dbContext.EmployeesData.Find(employee.ID);
                entity.ID = employee.ID;
                entity.Name = employee.Name;
                entity.Department = employee.Department;
                entity.Salary = employee.Salary;
                entity.IsManager = employee.IsManager;
                entity.Manager = employee.Manager;
                entity.Phone = employee.Phone;
                entity.Email = employee.Email;
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
                return "Students Updated Successfully!!!";
            }
            return "Model is null!";
        }
    }
}
