using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Data.Repository
{
    public interface IServiceRepository
    {
        bool AddService(tbl_Services model);
        IQueryable<tbl_Services> GetServices();
        
    }
}
