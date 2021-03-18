﻿using Assignment1.Business.Interface;
using Assignment1.BusinessEntities;
using Assignment1.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Business
{
    public class PassengerManager : IPassengerManager
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerManager(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public string AddPassengers(PassengerViewModel model)
        {
            return _passengerRepository.AddPassengers(model);
        }

        public bool DeletePassenger(int? id)
        {
            return _passengerRepository.DeletePassenger(id);
        }

        public PassengerViewModel GetPassenger(int? id)
        {
            return _passengerRepository.GetPassenger(id);
        }

        public List<PassengerViewModel> GetPassengers()
        {
            return _passengerRepository.GetPassengers();
        }

        public string UpdatePassengers(int id, PassengerViewModel model)
        {
            return _passengerRepository.UpdatePassengers(id,model);
        }
    }
}