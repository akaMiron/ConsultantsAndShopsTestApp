using CAS.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CAS.Business.Models
{
    public class AppointmentViewModel
    {
        [Display(Name="Store")]
        public int StoreId { get; set; }

        [Display(Name = "Consultant")]
        public int ConsultantId { get; set; }
    }
}