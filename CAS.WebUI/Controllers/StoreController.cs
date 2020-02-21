using CAS.Business;
using CAS.Business.Interfaces;
using CAS.Business.Models;
using Newtonsoft.Json;
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
        private IConsultantBusinessService _consultantBusinessService;

        public StoreController(IStoreBusinessService storeBusinessService, IConsultantBusinessService consultantBusinessService)
        {
            _storeBusinessService = storeBusinessService;
            _consultantBusinessService = consultantBusinessService;
        }



        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreModel storeModel)
        {
            _storeBusinessService.SaveStore(storeModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public string GetData()
        {
            List<StoreGridModel> stores = new List<StoreGridModel>();
            var storeModels = _storeBusinessService.GetStores().ToList();

            for (int i = 0, max = storeModels.Count(); i < max; i += 1)
            {
                var consultant = _consultantBusinessService.GetConsultants()
                    .Where(cons => cons.StoreId == storeModels[i].Id).OrderByDescending(cons => cons.AssignmentDate)
                    .FirstOrDefault();

                stores.Add(new StoreGridModel
                {
                    Id = storeModels[i].Id,
                    Name = storeModels[i].Name,
                    Address = storeModels[i].Address,
                    Consultant = (consultant != null) ? consultant.Name + " " + consultant.LastName : "",
                    AssignmentDate = (consultant != null) ? consultant.AssignmentDate : "" 
                });
            }

            var json = JsonConvert.SerializeObject(stores);
            return json;
        }


        //public ActionResult Edit(int id)
        //{
        //    StoreModel storeModel = _storeBusinessService.GetStore(id);
        //    if (storeModel != null)
        //    {
        //        return PartialView("EditStore", storeModel);
        //    }

        //    return View("Index");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(StoreModel storeModel)
        //{
        //    _storeBusinessService.SaveStore(storeModel);

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete(int id)
        //{
        //    StoreModel storeModel = _storeBusinessService.GetStore(id);
        //    if (storeModel != null)
        //    {
        //        return PartialView("Delete", storeModel);
        //    }

        //    return View("Index");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        //public ActionResult DeleteRecord(int id)
        //{
        //    StoreModel storeModel = _storeBusinessService.GetStore(id);

        //    if (storeModel != null)
        //    {
        //        _storeBusinessService.DeleteStore(id);
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}