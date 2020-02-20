using CAS.Data.Interfaces;
using CAS.Data.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Data.Infrastructure
{
    public static class NinjectBinder
    {
        public static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IStoreDataService>().To<StoreDataService>();
            kernel.Bind<IConsultantDataService>().To<ConsultantDataService>();
        }
    }
}
