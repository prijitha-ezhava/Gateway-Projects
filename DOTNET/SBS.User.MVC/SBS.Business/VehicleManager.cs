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
    public class VehicleManager : IVehicleManager
    {
        private IVehicleRepository _vehicleRepository;

        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public bool AddVehicle(VehicleViewModel model)
        {
            var config = new MapperConfiguration(cf => cf.CreateMap<VehicleViewModel, tbl_Vehicles>());
            IMapper mapper = config.CreateMapper();
            tbl_Vehicles vehicles = mapper.Map<VehicleViewModel, tbl_Vehicles>(model);
            return _vehicleRepository.AddVehicle(vehicles);
        }

        public bool DeleteVehicle(int ID)
        {
            return _vehicleRepository.DeleteVehicle(ID);
        }

        public List<VehicleViewModel> getVehicles()
        {
            var vehicleConfig = new MapperConfiguration(cf => cf.CreateMap<tbl_Vehicles, VehicleViewModel>());
            IMapper mapper = vehicleConfig.CreateMapper();
            return _vehicleRepository.getVehicles().ToList().Select(x => mapper.Map<tbl_Vehicles, VehicleViewModel>(x)).ToList();
        }
    }
}
