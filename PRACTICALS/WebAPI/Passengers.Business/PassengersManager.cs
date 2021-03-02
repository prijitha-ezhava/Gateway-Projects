using Passengers.Business.Interface;
using Passengers.BusinessEntities;
using Passengers.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Business
{
    public class PassengersManager : IPassengerManager
    {
        private readonly IPassengerRepository _passengerRepository;
        public PassengersManager(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public bool DeletePassengers(int? id)
        {
            throw new NotImplementedException();
        }

        public List<PassengersViewModel> GetPassengers()
        {
            throw new NotImplementedException();
        }

        public PassengersViewModel GetPassengers(int? id)
        {
            throw new NotImplementedException();
        }

        public string PostPassengers(PassengersViewModel passengers)
        {
            throw new NotImplementedException();
        }

        public string PutPassengers(int id, PassengersViewModel passengers)
        {
            throw new NotImplementedException();
        }
    }
}
