using SBS.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.Admin.MVC.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleManager _vehicleManager;

        public VehiclesController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }
        // GET: Vehicles
        public ActionResult Index(int? customerID)
        {
            var vehicles = _vehicleManager.getVehicles().Where(x => x.custID == customerID);
            return View(vehicles);
        }
    }
}