using Passengers.BusinessEntities;
using Passengers.DataLayer.Models;
using Passengers.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.DataLayer
{
    public class PassengerRepository : IPassengerRepository
    {
        private PassengersDBEntities _dbContext;

        public PassengerRepository()
        {
            _dbContext = new PassengersDBEntities();
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

        public string PostPassengers(PassengersViewModel model)
        {
            try
            {
                if (passengers != null)
                {
                    Passengers passengers = new Passengers();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string PutPassengers(int id, PassengersViewModel passengers)
        {
            throw new NotImplementedException();
        }
    }
}
