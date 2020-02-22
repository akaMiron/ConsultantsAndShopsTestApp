using CAS.DataStorage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Models
{
    public class ConsultantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? StoreId { get; set; }
        public string AssignmentDate { get; set; }

        public string FullName { 
            get {
                return Name + " " + LastName;
            } 
        }
    }
}
