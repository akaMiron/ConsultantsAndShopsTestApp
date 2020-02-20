using CAS.DataStorage;
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
        public DateTime? AssignmentDate { get; set; }
        public tblStore Store { get; set; }
    }
}
