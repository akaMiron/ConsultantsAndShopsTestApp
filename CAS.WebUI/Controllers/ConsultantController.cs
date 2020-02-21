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
    public class ConsultantController : Controller
    {
        private IConsultantBusinessService _consultantBusinessService;
        private IStoreBusinessService _storesBusinessService;
        private IAppointmentBusinessService _appointmentBusinessService;

        public ConsultantController(IConsultantBusinessService consultantBusinessService, 
            IStoreBusinessService storesBusinessService,
            IAppointmentBusinessService appointmentBusinessService)
        {
            _consultantBusinessService = consultantBusinessService;
            _storesBusinessService = storesBusinessService;
            _appointmentBusinessService = appointmentBusinessService;
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultantModel consultantModel)
        {
            _consultantBusinessService.SaveConsultant(consultantModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Appoint()
        {
            AppointmentListsViewModel model = _appointmentBusinessService.CreateListViewModel();

            return PartialView("Appoint", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Appoint(AppointmentListsViewModel appointmentViewModel)
        {
            var consultant = _consultantBusinessService.GetConsultant(appointmentViewModel.BindModel.ConsultantId);
            consultant.StoreId = appointmentViewModel.BindModel.StoreId;
            consultant.AssignmentDate = DateTime.Now.ToString();

            _consultantBusinessService.SaveConsultant(consultant);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public string GetData()
        {
            var stores = _consultantBusinessService.GetConsultants().ToList();

            return JsonConvert.SerializeObject(stores);
        }
    }
}