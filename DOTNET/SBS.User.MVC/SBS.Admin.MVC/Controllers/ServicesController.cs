using SBS.Business.Interfaces;
using SBS.BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.Admin.MVC.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ServicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Services
        [Route("Services/Index/{mechID}")]
        public ActionResult Index(int? mechID)
        {
            var services = _serviceManager.GetServices().Where(x => x.mechanicID == mechID);
            return View(services);
        }

        //GET: Services/Create
        public ActionResult Create(int mechID)
        {
            TempData["mechanic"] = mechID;
            return View();
        }

        //POST: Services/Create
        [HttpPost]
        public ActionResult Create(ServiceViewModel model)
        {
            int mechId = Convert.ToInt32(TempData["mechanic"]);
            model.mechanicID = Convert.ToInt32(TempData["mechanic"]);
            model.IsActive = true;
            _serviceManager.AddService(model);
            return RedirectToAction("Index/"+mechId, "Services");
        }
    }
}