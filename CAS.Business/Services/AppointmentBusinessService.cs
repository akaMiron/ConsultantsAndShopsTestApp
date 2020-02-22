using CAS.Business.Interfaces;
using CAS.Business.Models;
using System;
using System.Web.Mvc;

namespace CAS.Business.Services
{
    public class AppointmentBusinessService : IAppointmentBusinessService
    {
        private IStoreBusinessService _storeBusinessService;
        private IConsultantBusinessService _consultantBusinessService;

        public AppointmentBusinessService(IStoreBusinessService storeBusinessService, IConsultantBusinessService consultantBusinessService)
        {
            _storeBusinessService = storeBusinessService;
            _consultantBusinessService = consultantBusinessService;
        }

        public AppointmentListsViewModel CreateListViewModel()
        {
            AppointmentListsViewModel model = new AppointmentListsViewModel
            {
                BindModel = new AppointmentViewModel()
            };

            model.Consultants = new SelectList(_consultantBusinessService.GetConsultants(), "Id", "Name", model.BindModel.ConsultantId);
            model.Stores = new SelectList(_storeBusinessService.GetStores(), "Id", "Name", model.BindModel.StoreId);

            return model;
        }

        public void AppointConsultant(AppointmentListsViewModel appointmentViewModel)
        {
            var consultant = _consultantBusinessService.GetConsultant(appointmentViewModel.BindModel.ConsultantId);
            consultant.StoreId = appointmentViewModel.BindModel.StoreId;
            consultant.AssignmentDate = DateTime.Now.ToString();

            _consultantBusinessService.SaveConsultant(consultant);
        }
    }
}
