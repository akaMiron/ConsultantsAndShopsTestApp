using CAS.Business;
using CAS.Business.Interfaces;
using CAS.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;

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
            var store = new StoreModel();
            return PartialView("Create", store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                _storeBusinessService.SaveStore(storeModel);

                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetData()
        {
            // todo: move to common service
            // create model for grid props

            int start = Convert.ToInt32(Request.QueryString["start"]);
            int length = Convert.ToInt32(Request.QueryString["length"]);
            string sortColumnName = Request.QueryString["columns[" + Request.QueryString["order[0][column]"] + "][name]"];
            string sortDirection = Request.QueryString["order[0][dir]"];

            var stores = _storeBusinessService.GetStores().ToList();
            var consultants = _consultantBusinessService.GetConsultants();

            var totalRecords = stores.Count();

            List<StoreGridModel> gridRows = stores.Select(x => new StoreGridModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                // todo: 
                // workaroud, this is too slow
                Consultant = consultants.Where(cons => cons.StoreId == x.Id).OrderByDescending(cons => cons.AssignmentDate).FirstOrDefault()?.FullName,
                AssignmentDate = consultants.Where(cons => cons.StoreId == x.Id).OrderByDescending(cons => cons.AssignmentDate).FirstOrDefault()?.AssignmentDate
            }).OrderBy(sortColumnName + " " + sortDirection).ToList();

            gridRows = gridRows.Skip(start).Take(length).ToList();

            return Json(new { data = gridRows, draw = Request["draw"], recordsTotal =  totalRecords, recordsFiltered = totalRecords }, JsonRequestBehavior.AllowGet);
        }

    }
}