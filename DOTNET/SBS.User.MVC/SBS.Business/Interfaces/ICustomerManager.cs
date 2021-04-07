using SBS.BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
    public interface ICustomerManager
    {
        bool AddCustomer(CustomerViewModel model);
        /*string CustomerLogin(CustomerViewModel model);*/
        List<CustomerViewModel> getCustomers();
    }
}
