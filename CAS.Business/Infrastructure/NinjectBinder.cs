using CAS.Business.Interfaces;
using CAS.Business.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Infrastructure
{
    public class NinjectBinder
    {
        public static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IStoreBusinessService>().To<StoreBusinessService>();
            kernel.Bind<IConsultantBusinessService>().To<ConsultantBusinessService>();
        }
    }
}
