using BAL.Interface;
using BusinessEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeeCRUD.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly ILogger _logger;

        public EmployeeController(IEmployeeManager employeeManager, ILoggerFactory logger)
        {
            _employeeManager = employeeManager;
            logger.AddFile("Logs/EmployeeErrorLog.txt");
            _logger = logger.CreateLogger("MyCategory");
        }

        //To View all employees details 
        //GET: /Employee/Index
        [ResponseCache(Duration = (int)0.5)]
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = _employeeManager.GetAllemployees();
                return View(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
        }

        // GET: Employee/Details/5
        public IActionResult Details(int? id)
        {
            try
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            } 
        }

        //To Add new employee record 
        //GET: /Employee/AddEmployee
        [HttpGet]
        public IActionResult AddEmployee()
        {
            try
            {
                return View();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            } 
        }

        //POST: /Employee/AddEmployee
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string addEmployee = _employeeManager.AddEmployee(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }  
        }

        //To Update the records of a particular employee 
        //GET: /Employee/EditEmployee/{id}
        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            try
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
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
            try
            {
                if (id == null)
                    return NotFound();

                var employee = _employeeManager.GetEmployee(id);
                if (employee == null)
                    return NotFound();

                return View(employee);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           

        }

        //POST: /Employee/DeleteEmployee/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _employeeManager.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
        }
    }
}
