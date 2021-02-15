using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Data.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private DB_VMSEntities dbContext = new DB_VMSEntities();

        public bool AddVehicle(tbl_Vehicles model)
        {
            dbContext.tbl_Vehicles.Add(model);
            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteVehicle(int ID)
        {
            var vehicle = dbContext.tbl_Vehicles.Find(ID);
            dbContext.tbl_Vehicles.Remove(vehicle);
            return dbContext.SaveChanges() > 0;
        }

        public IQueryable<tbl_Vehicles> getVehicles()
        {
            return dbContext.tbl_Vehicles;
        }
    }
}
