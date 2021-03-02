using PassengersCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PassengersCRUD.Controllers
{
    public class PassengersController : Controller
    {
        // GET: Passengers
        public ActionResult Index()
        {
            IEnumerable<PassengersViewModel> passengers;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Passengers").Result;
            passengers = response.Content.ReadAsAsync<IEnumerable<PassengersViewModel>>().Result;
            return View(passengers);
        }

        public ActionResult AddOrUpdate(int Id = 0)
        {
            if (Id == 0)
                return View(new PassengersViewModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Passengers/" + Id.ToString()).Result;
                return View(response.Content.ReadAsAsync<PassengersViewModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrUpdate(PassengersViewModel passengers)
        {
            if (passengers.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Passengers", passengers).Result;
                TempData["SuccessMsg"] = "Saved Successfully!!";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Passengers/"+passengers.ID, passengers).Result;
                TempData["SuccessMsg"] = "Updated Successfully!!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Passengers/" + Id.ToString()).Result;
            TempData["SuccessMsg"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}