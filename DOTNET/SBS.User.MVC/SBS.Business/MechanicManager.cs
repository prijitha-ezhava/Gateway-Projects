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
    public class MechanicManager : IMechanicManager
    {
        private readonly IMechanicRepository _mechanicRepository;
        public MechanicManager(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }
        public bool AddMechanic(MechanicViewModel model)
        {
            var mechconfig = new MapperConfiguration(cfg =>cfg.CreateMap<MechanicViewModel,tbl_Mechanics>());
            IMapper mechMapper = mechconfig.CreateMapper();
            var mechanic = mechMapper.Map<MechanicViewModel, tbl_Mechanics>(model);
            return _mechanicRepository.AddMechanic(mechanic);
        }

        public List<MechanicViewModel> getMechanics()
        {
            var mechConfig = new MapperConfiguration(cfg => cfg.CreateMap<tbl_Mechanics, MechanicViewModel>());
            IMapper mechMapper = mechConfig.CreateMapper();
            return _mechanicRepository.getMechanics().ToList().Select(x => mechMapper.Map<tbl_Mechanics, MechanicViewModel>(x)).ToList();
        }

        
    }
}
