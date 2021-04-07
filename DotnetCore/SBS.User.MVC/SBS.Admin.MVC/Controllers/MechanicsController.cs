using SBS.Business.Interfaces;
using SBS.BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.Admin.MVC.Controllers
{
    public class MechanicsController : Controller
    {
        private readonly IMechanicManager _mechanicManager;
        public MechanicsController(IMechanicManager mechanicManager)
        {
            _mechanicManager = mechanicManager;
        }
        // GET: Mechanics
        public ActionResult Index()
        {
            var mechanicList = _mechanicManager.getMechanics();
            return View(mechanicList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MechanicViewModel model)
        {
            _mechanicManager.AddMechanic(model);
            return RedirectToAction("Index");
        }
    }
}