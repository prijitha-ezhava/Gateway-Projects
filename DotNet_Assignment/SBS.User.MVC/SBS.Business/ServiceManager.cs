using AutoMapper;
using SBS.Business.Interfaces;
using SBS.BusinessEntities.ViewModel;
using SBS.Data.Database;
using SBS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public bool AddService(ServiceViewModel model)
        {
            var addConfig = new MapperConfiguration(cfg => cfg.CreateMap<ServiceViewModel, tbl_Services>());
            IMapper addMapper = addConfig.CreateMapper();
            var services = addMapper.Map<ServiceViewModel, tbl_Services>(model);
            return _serviceRepository.AddService(services);
        }

        

        public List<ServiceViewModel> GetServices()
        {
            var listConfig = new MapperConfiguration(cfg => cfg.CreateMap<tbl_Services, ServiceViewModel>());
            IMapper listMapper = listConfig.CreateMapper();
            return _serviceRepository.GetServices().ToList().Select(x=>listMapper.Map<tbl_Services, ServiceViewModel>(x)).ToList();
        }
    }
}
