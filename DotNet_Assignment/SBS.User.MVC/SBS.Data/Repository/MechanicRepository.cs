using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Data.Repository
{
    public class MechanicRepository : IMechanicRepository
    {
        private DB_VMSEntities _dbContext = new DB_VMSEntities();
        public bool AddMechanic(tbl_Mechanics model)
        {
            _dbContext.tbl_Mechanics.Add(model);
            return _dbContext.SaveChanges() > 0;
        }

        public IQueryable<tbl_Mechanics> getMechanics()
        {
            return _dbContext.tbl_Mechanics;
        }
    }
}
