﻿using CAS.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Interfaces
{
    public interface IAppointmentBusinessService
    {
        AppointmentListsViewModel CreateListViewModel();
        void AppointConsultant(AppointmentListsViewModel appointmentViewModel);
    }
}
