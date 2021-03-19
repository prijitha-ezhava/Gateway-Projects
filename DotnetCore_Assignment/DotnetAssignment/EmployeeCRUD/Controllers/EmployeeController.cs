using BAL.Interface;
using BusinessEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmployeeCRUD.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        //To View all employees details 
        //GET: /Employee/Index
        [ResponseCache(Duration = (int)0.5)]
        [HttpGet]
        public IActionResult Index()
        {
            var result = _employeeManager.GetAllemployees();
            return View(result);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //To Add new employee record 
        //GET: /Employee/AddEmployee
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        //POST: /Employee/AddEmployee
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                string addEmployee = _employeeManager.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //To Update the records of a particular employee 
        //GET: /Employee/EditEmployee/{id}
        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //POST: /Employee/EditEmployee/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string editEmployee = _employeeManager.UpdateEmployee(employee);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //To Delete the record on a particular employee 
        //GET: /Employee/DeleteEmployee/{id}
        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
                return NotFound();

            return View(employee);

        }

        //POST: /Employee/DeleteEmployee/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeManager.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
