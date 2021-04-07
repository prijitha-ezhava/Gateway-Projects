using BAL.Interface;
using BusinessEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeAPIController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
       public ActionResult Index()
        {
            return StatusCode(200, _employeeManager.GetAllemployees());
        }

        //[HttpGet]
        //public ActionResult Details(int? id)
        //{
        //    return StatusCode(200, _employeeManager.GetEmployee(id));
        //}
        //[HttpPost]
        //public ActionResult AddEmployees(EmployeeViewModel model)
        //{
        //    return StatusCode(200, _employeeManager.AddEmployee(model));
        //}

        //[HttpPut]
        //public ActionResult EditEmployee(int? id, EmployeeViewModel model)
        //{
        //    return StatusCode(200, _employeeManager.UpdateEmployee(model));
        //}

        //[HttpPost]
        //public ActionResult DeleteEmployee(int id)
        //{
        //    return StatusCode(200, _employeeManager.DeleteEmployee(id));
        //}

    }
}
