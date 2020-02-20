using CAS.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAS.WebUI.Controllers
{
    public class StoreController : Controller
    {
        private IStoreBusinessService _storeBusinessService;

        public StoreController(IStoreBusinessService storeBusinessService)
        {
            _storeBusinessService = storeBusinessService;
        }

        public ActionResult List()
        {
            return View(_storeBusinessService.GetStores().ToList());
        }
    }
}