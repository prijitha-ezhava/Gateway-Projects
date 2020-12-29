using log4net;
using ProductManagement.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class UserController : Controller
    {
        //log4net
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(LoginController));

        // GET: User
        db_ProductsEntities1 dbObj = new db_ProductsEntities1();
        public ActionResult Users()
        {
            //lognet messages
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");

            return View();
        }

        [HttpPost]
        public ActionResult AddUser(tbl_Users model)
        {
            /*if(ModelState.IsValid)
            { 
                tbl_Users obj = new tbl_Users();
                obj.User_Name = model.User_Name;
                obj.User_Password = model.User_Password;
                obj.User_ConfirmPassword = model.User_ConfirmPassword;

                dbObj.tbl_Users.Add(obj);
                dbObj.SaveChanges();
            }

            ModelState.Clear();*/

            HttpResponseMessage response = GlobalVariables.webApiCLient.PostAsJsonAsync("tbl_Users", model).Result;
            TempData["successMsg"] = "Registration  Successfully";

            return RedirectToAction("Login", "Login", new { area = "" });
        }
    }
}