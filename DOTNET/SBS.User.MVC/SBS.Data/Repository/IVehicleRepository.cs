using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Data.Repository
{
    public interface IVehicleRepository
    {
        bool AddVehicle(tbl_Vehicles model);
        IQueryable<tbl_Vehicles> getVehicles();
        bool DeleteVehicle(int ID);
    }
}

