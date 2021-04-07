using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using log4net;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.Controllers
{
    public class HomeController : Controller
    {
        //log4net
        private static log4net.ILog Log{get;set;}
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        //Return Login View
        public ActionResult Login()
        {
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");
            return View();
        }

        //Login
        //Authenticating User
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            using(var context = new UserRegistrationEntities())
            {
                var activeUser = context.tblUserDetails.Where(x => x.uEmail == model.uEmail && x.uPassword == model.uPassword).SingleOrDefault();
                if (activeUser != null)
                {
                    Session["UserID"] = activeUser.uID;
                    Session["Username"] = activeUser.uName;
                    Session["EmailID"] = activeUser.uEmail;
                    Session["Age"] = activeUser.uAge;
                    Session["Address"] = activeUser.uAddress;
                    Session["Phone"] = activeUser.uPhone;
                    Session["ProfileImg"] = activeUser.uProfileImg;
                    return View("Dashboard", activeUser);
                }
                else
                {
                    TempData["msg"] = "Please Enter Valid Email or Password!!";
                    return View("Login");
                }
            }
        }

        //Dashboard

        public ActionResult Dashboard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            /*UserRegistrationEntities obj = new UserRegistrationEntities();
            var res = obj.tblUserDetails.Single(x => x.uID == uID);*/
            // return View(obj);
        }
        //Signout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }



    }
}