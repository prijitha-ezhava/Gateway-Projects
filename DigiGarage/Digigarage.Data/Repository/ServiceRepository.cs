using Digigarage.BusinessEntities;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using Digigarage.Data.Models;
using AutoMapper;
using System.Data.Entity;
using System.Linq;

namespace Digigarage.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DigigarageEntities _dbContext;

        public ServiceRepository()
        {
            _dbContext = new DigigarageEntities();
        }
        public string CreateService(ServiceViewModel model)
        {
            
            if (model != null)
            {
                Service entity = Mapper.Map<ServiceViewModel,Service>(model);
                _dbContext.Services.Add(entity);
                _dbContext.SaveChanges();
                return "Service added";
            }

            return "Model is null";
        }

        public string DeleteService(int? Id)
        {
            Service entity = _dbContext.Services.Find(Id);
            _dbContext.Services.Remove(entity);
            _dbContext.SaveChanges();
            return "Deleted";
        }

        public IEnumerable<ServiceViewModel> GetAllService()
        {
            IEnumerable<ServiceViewModel> ServicesEntities =
                Mapper.Map<IEnumerable<ServiceViewModel>>(_dbContext.Services);
            return ServicesEntities;
        }

        public IEnumerable<StautsOfBookingViewModel> GetAllServiceStatus()
        {
            IEnumerable<StautsOfBookingViewModel> ServicesStatusEntities =
                Mapper.Map<IEnumerable<StautsOfBookingViewModel>>(_dbContext.StautsOfBookings);
            return ServicesStatusEntities;
        }

        public ServiceViewModel GetService(int? Id)
        {
            ServiceViewModel ServicesEntitie = Mapper.Map<ServiceViewModel>(_dbContext.Services.Find(Id));
            return ServicesEntitie;
        }

        public string UpdateService(ServiceViewModel model)
        {
            if (model != null)
            {
                Service entity = _dbContext.Services.Find(model.ServiceId);
                Mapper.Map(model, entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return "Service updated";
            }

            return "Model is null";
        }
    }
}
