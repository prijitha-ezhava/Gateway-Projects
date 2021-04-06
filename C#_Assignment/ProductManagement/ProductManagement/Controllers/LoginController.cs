using log4net;
using ProductManagement.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class LoginController : Controller
    {
        //log4net
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(LoginController));

        // GET: Login
        ProductManagementEntities dbObj = new ProductManagementEntities();
        public ActionResult Login()
        {
            //lognet messages
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");

            return View();
        }

        public ActionResult Dashboard(tbl_Users obj)
        {
            return View(obj);
        }

        public ActionResult IsValidUser(tbl_Users model)
        {
            var searchUser = dbObj.tbl_Users.Where(x => x.UserName == model.UserName).SingleOrDefault();
            if(searchUser!=null)
            {
                Session["Username"] = searchUser.UserName;
                return View("Dashboard", searchUser);
            }
            else
            {
                return View("Login");
            }
           
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}