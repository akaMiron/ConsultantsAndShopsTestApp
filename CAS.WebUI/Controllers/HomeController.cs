using CAS.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IStoreBusinessService _storeBusinessService;

        public HomeController(IStoreBusinessService storeBusinessService)
        {
            _storeBusinessService = storeBusinessService;
        }

        public ActionResult Index()
        {
            return View(_storeBusinessService.GetStores().ToList());
        }
    }
}