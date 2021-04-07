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
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        

        //GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel model)
        {
            _customerManager.AddCustomer(model);
            TempData["successMsg"] = "Registered  Successfully !";
            return RedirectToAction("Login");
        }

        //GET: Customer/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerViewModel model)
        {
            bool isValidUser = _customerManager.getCustomers().Any(x => x.EmailID == model.EmailID && x.Password == model.Password);
            if(isValidUser)
            {
                FormsAuthentication.SetAuthCookie(model.EmailID, false);
                Session["ActiveUser"] =  _customerManager.getCustomers().Where(x => x.EmailID == model.EmailID && x.Password == model.Password).First().ID;
                return RedirectToAction("Index","Vehicle");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials for Login..!");
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}

