using SourceControlFinalAssignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace SourceControlFinalAssignment.Controllers
{
    public class UserRegController : Controller
    {
        UserRegistrationEntities dbObj = new UserRegistrationEntities();
        // GET: UserReg
        public ActionResult Users()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Users([Bind(Include = "uID,uName,uEmail,uPassword,uConfirmPassword,uAge,uAddress,uPhone,uProfileImg")] tblUserDetails model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        file.SaveAs(path);
                        model.uProfileImg = "~/Images/" + fileName;
                    }

                    dbObj.tblUserDetails.Add(model);
                    dbObj.SaveChanges();   
                }  
            }

            catch
            {
                return View();
            }
            ModelState.Clear();


            return RedirectToAction("Login","Home", new { area = ""});
        }
    }
}