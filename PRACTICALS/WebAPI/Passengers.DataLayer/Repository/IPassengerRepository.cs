﻿using Passengers.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.DataLayer.Repository
{
    public interface IPassengerRepository
    {
        List<PassengersViewModel> GetPassengers();
        string PostPassengers(PassengersViewModel passengers);
        bool DeletePassengers(int? id);
        PassengersViewModel GetPassengers(int? id);
        string PutPassengers(int id, PassengersViewModel passengers);
    }
}