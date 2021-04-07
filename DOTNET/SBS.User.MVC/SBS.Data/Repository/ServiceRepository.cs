using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private DB_VMSEntities _dbContext = new DB_VMSEntities();
        public bool AddService(tbl_Services model)
        {
            _dbContext.tbl_Services.Add(model);
            return _dbContext.SaveChanges() > 0;
        }


        public IQueryable<tbl_Services> GetServices()
        {
            return _dbContext.tbl_Services;
        }
    }
}
