using Assignment1.BusinessEntities;
using Assignment1.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Data.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly PassengersDBEntities _dbContext;

        public PassengerRepository()
        {
            _dbContext = new PassengersDBEntities();
        }
        public string AddPassengers(PassengerViewModel model)
        {
            try
            {
                if (model != null)
                {
                    Passengers passengers = new Passengers();
                    passengers.ID = model.ID;
                    passengers.FirstName = model.FirstName;
                    passengers.LastName = model.LastName;
                    passengers.Mobile = model.Mobile;
                    _dbContext.Passengers.Add(passengers);
                    _dbContext.SaveChanges();
                    return "Passenger Added Successfully";
                }
                return "Model is null !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeletePassenger(int? id)
        {
            var entity = _dbContext.Passengers.Find(id);
            if (entity != null)
            {
                _dbContext.Passengers.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public PassengerViewModel GetPassenger(int? id)
        {
            try
            {
                var entity = _dbContext.Passengers.Find(id);
                PassengerViewModel passenger = new PassengerViewModel();
                passenger.ID = entity.ID;
                passenger.FirstName = entity.FirstName;
                passenger.LastName = entity.LastName;
                passenger.Mobile = entity.Mobile;
                return passenger;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PassengerViewModel> GetPassengers()
        {
            var entity = _dbContext.Passengers.ToList();
            List<PassengerViewModel> passengersList = new List<PassengerViewModel>();
            if (_dbContext != null)
            {
                foreach(var item in entity)
                {
                    PassengerViewModel passenger = new PassengerViewModel();
                    passenger.ID = item.ID;
                    passenger.FirstName = item.FirstName;
                    passenger.LastName = item.LastName;
                    passenger.Mobile = item.Mobile;
                    passengersList.Add(passenger);
                }
            }
            return passengersList;
        }

        public string UpdatePassengers(int id, PassengerViewModel model)
        {
            try
            {
                Passengers passenger = new Passengers();
                if (model != null)
                {
                    passenger.ID = model.ID;
                    passenger.FirstName = model.FirstName;
                    passenger.LastName = model.LastName;
                    passenger.Mobile = model.Mobile;
                    _dbContext.Entry(passenger).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return "Passenger Updated Successfully";
                }
                return "Model is null!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
