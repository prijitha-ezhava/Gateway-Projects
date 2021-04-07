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
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool AddCustomer(CustomerViewModel model)
        {
            var customerConfig = new MapperConfiguration(cf => cf.CreateMap<CustomerViewModel, tbl_Customers>());
            IMapper customerMapper = customerConfig.CreateMapper();
            tbl_Customers customers = customerMapper.Map<CustomerViewModel, tbl_Customers>(model);
            return _customerRepository.AddCustomer(customers);
        }


        /*public string CustomerLogin(CustomerViewModel model)
        {
            var customerConfig = new MapperConfiguration(cf => cf.CreateMap<CustomerViewModel, tbl_Customers>());
            IMapper customerMapper = customerConfig.CreateMapper();
            tbl_Customers customers = customerMapper.Map<CustomerViewModel, tbl_Customers>(model);
            return _customerRepository.CustomerLogin(customers);
        }*/

        public List<CustomerViewModel> getCustomers()
        {
            var custconfig = new MapperConfiguration(cfg => cfg.CreateMap<tbl_Customers, CustomerViewModel>());
            IMapper custMapper = custconfig.CreateMapper();
            return _customerRepository.getCustomers().ToList().Select(x => custMapper.Map<tbl_Customers, CustomerViewModel>(x)).ToList();

        }
    }
}
