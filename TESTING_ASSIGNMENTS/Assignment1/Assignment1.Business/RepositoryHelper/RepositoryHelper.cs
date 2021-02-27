using Assignment1.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace Assignment1.Business.RepositoryHelper
{
    public class RepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPassengerRepository, PassengerRepository>();
        }
    }
}
