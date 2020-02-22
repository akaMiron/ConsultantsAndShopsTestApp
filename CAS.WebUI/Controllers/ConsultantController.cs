using CAS.Business;
using CAS.Business.Interfaces;
using CAS.Business.Models;
using System;
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
            var consultant = new ConsultantModel();
            return PartialView("Create", consultant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(ConsultantModel consultantModel)
        {
            if (ModelState.IsValid)
            {
                _consultantBusinessService.SaveConsultant(consultantModel);

                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
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
            if (ModelState.IsValid)
            {
                _appointmentBusinessService.AppointConsultant(appointmentViewModel);

                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}