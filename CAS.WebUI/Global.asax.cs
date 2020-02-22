using CAS.Common.Models.DataTables;
using CAS.WebUI.Infrastructure;
using Ninject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CAS.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(new StandardKernel()));
            //ModelBinders.Binders.Add(typeof(DataTableRequest), new DataTableModelBinder());
        }
    }
}
