using Assignment1.Business.Interface;
using Assignment1.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace Assignment1.WebAPI.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IPassengerManager _passengerManager;

        public PassengerController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }

        // GET: api/Passenger
        public List<PassengerViewModel> GetPassengers()
        {
            return _passengerManager.GetPassengers();
        }

        // GET: api/Passenger/5
        public PassengerViewModel GetPassenger(int id)
        {
            return _passengerManager.GetPassenger(id);
        }

        // POST: api/Passenger
        public string PostPassenger(PassengerViewModel model)
        {
            return _passengerManager.AddPassengers(model);
        }

        // PUT: api/Passenger/5
        public string UpdatePassenger(int id, PassengerViewModel model)
        {
            return _passengerManager.UpdatePassengers(id, model);
        }

        // DELETE: api/Passengers/5
        public bool DeletePassenger(int id)
        {
            return _passengerManager.DeletePassenger(id);
        }
    }
}
