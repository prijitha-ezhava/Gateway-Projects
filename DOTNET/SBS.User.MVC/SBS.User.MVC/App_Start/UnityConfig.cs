using SBS.Business;
using SBS.Business.Helper;
using SBS.Business.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SBS.User.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IVehicleManager, VehicleManager>();
            container.RegisterType<IMechanicManager, MechanicManager>();
            container.RegisterType<IServiceManager, ServiceManager>();
            container.AddNewExtension<UnityRepositoryHelper>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}