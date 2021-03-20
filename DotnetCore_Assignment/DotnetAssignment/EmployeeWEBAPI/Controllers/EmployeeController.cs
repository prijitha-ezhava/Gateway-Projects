using BAL.Interface;
using BusinessEntities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace EmployeeWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        //private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return StatusCode(200, _employeeManager.GetAllemployees().ToList());
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public ActionResult GetEmployee(int? id)
        {
            return StatusCode(200, _employeeManager.GetEmployee(id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public ActionResult AddEmployee(EmployeeViewModel employee)
        {
            return StatusCode(200, _employeeManager.AddEmployee(employee));
        }

        [HttpPut]
        [Route("EditEmployee")]
        public ActionResult EditEmployee(int? id, EmployeeViewModel employee)
        {
            return StatusCode(200, _employeeManager.UpdateEmployee(employee));
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public ActionResult DeleteEmployee(int id)
        {
            return StatusCode(200, _employeeManager.DeleteEmployee(id));
        }
    }
}
