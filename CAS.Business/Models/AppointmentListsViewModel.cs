using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAS.Business.Models
{
    public class AppointmentListsViewModel
    {
        public AppointmentViewModel BindModel { get; set; }
        public SelectList Stores { get; set; }
        public SelectList Consultants { get; set; }
}
}