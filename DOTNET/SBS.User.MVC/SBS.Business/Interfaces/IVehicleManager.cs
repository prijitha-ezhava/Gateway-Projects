using SBS.BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
    public interface IVehicleManager
    {
        List<VehicleViewModel> getVehicles();
        bool AddVehicle(VehicleViewModel model);
        bool DeleteVehicle(int ID);
    }
}
