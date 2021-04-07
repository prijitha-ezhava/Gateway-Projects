using SBS.BusinessEntities.ViewModel;
using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Data.Repository
{
    public interface ICustomerRepository
    {
        bool AddCustomer(tbl_Customers model);
        /*string CustomerLogin(tbl_Customers model);*/
        IQueryable<tbl_Customers> getCustomers();
    }
}
