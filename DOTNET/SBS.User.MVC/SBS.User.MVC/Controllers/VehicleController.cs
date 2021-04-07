using SBS.Business.Interfaces;
using SBS.BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SBS.User.MVC.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleManager _vehicleManager;

        public VehicleController(IVehicleManager VehicleManager)
        {
            _vehicleManager = VehicleManager;
        }

        public ActionResult Index()
        {
            int userID = Convert.ToInt32(Session["ActiveUser"]);
            var vehicles = _vehicleManager.getVehicles().Where(x => x.custID == userID);
            return View(vehicles);
        }

        //GET: Vehicle/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(VehicleViewModel model)
        {
            model.custID = Convert.ToInt32(Session["ActiveUser"]);
            _vehicleManager.AddVehicle(model);
            return RedirectToAction("Index", "Home");
        }

        public JsonResult Delete(int ID)
        {
            return Json(_vehicleManager.DeleteVehicle(ID), JsonRequestBehavior.AllowGet);
        }

        


    }
}

